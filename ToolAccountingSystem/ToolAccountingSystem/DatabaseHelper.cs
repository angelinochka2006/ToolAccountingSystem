using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ToolAccountingSystem.Models;

namespace ToolAccountingSystem
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ToolAccountingSystem"].ConnectionString;
        }

        public User AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT u.*, r.Name as RoleName 
                               FROM Users u 
                               INNER JOIN Roles r ON u.RoleId = r.Id 
                               WHERE u.Username = @Username AND u.PasswordHash = @Password AND u.IsActive = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        RoleName = reader["RoleName"].ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                    };
                }
                return null;
            }
        }

        public DataTable GetTools(int pageNumber = 1, int pageSize = 10)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Tools 
                               ORDER BY Id 
                               OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public int GetToolsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Tools";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public DataTable GetStorageLocations()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT sl.*, u.FullName as ResponsibleUserName 
                               FROM StorageLocations sl 
                               LEFT JOIN Users u ON sl.ResponsibleUserId = u.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetUsersByRole(int roleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE RoleId = @RoleId AND IsActive = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoleId", roleId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public bool AddToolOperation(ToolOperation operation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ToolOperations 
                               (ToolId, StorageLocationId, UserId, WorkerUserId, OperationType, Quantity, OperationDate, Notes) 
                               VALUES (@ToolId, @StorageLocationId, @UserId, @WorkerUserId, @OperationType, @Quantity, GETDATE(), @Notes)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ToolId", operation.ToolId);
                command.Parameters.AddWithValue("@StorageLocationId", operation.StorageLocationId);
                command.Parameters.AddWithValue("@UserId", operation.UserId);
                command.Parameters.AddWithValue("@WorkerUserId", operation.WorkerUserId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@OperationType", operation.OperationType);
                command.Parameters.AddWithValue("@Quantity", operation.Quantity);
                command.Parameters.AddWithValue("@Notes", operation.Notes ?? "");

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetToolBalance(int storageLocationId = 0)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    WITH Operations AS (
                        SELECT 
                            ToolId,
                            StorageLocationId,
                            CASE 
                                WHEN OperationType IN ('приёмка', 'возврат') THEN Quantity
                                WHEN OperationType IN ('списание', 'выдача') THEN -Quantity
                                ELSE 0
                            END as QuantityChange
                        FROM ToolOperations
                    ),
                    Balance AS (
                        SELECT 
                            ToolId,
                            StorageLocationId,
                            SUM(QuantityChange) as Balance
                        FROM Operations
                        GROUP BY ToolId, StorageLocationId
                    )
                    SELECT 
                        b.ToolId,
                        t.Article,
                        t.Name as ToolName,
                        b.StorageLocationId,
                        sl.Name as StorageLocationName,
                        b.Balance
                    FROM Balance b
                    INNER JOIN Tools t ON b.ToolId = t.Id
                    INNER JOIN StorageLocations sl ON b.StorageLocationId = sl.Id
                    WHERE b.Balance > 0";

                if (storageLocationId > 0)
                {
                    query += " AND b.StorageLocationId = @StorageLocationId";
                }

                query += " ORDER BY t.Name";

                SqlCommand command = new SqlCommand(query, connection);
                if (storageLocationId > 0)
                {
                    command.Parameters.AddWithValue("@StorageLocationId", storageLocationId);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetWorkerTools(int workerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    WITH Issued AS (
                        SELECT ToolId, SUM(Quantity) as IssuedQuantity
                        FROM ToolOperations 
                        WHERE WorkerUserId = @WorkerId AND OperationType = 'выдача'
                        GROUP BY ToolId
                    ),
                    Returned AS (
                        SELECT ToolId, SUM(Quantity) as ReturnedQuantity
                        FROM ToolOperations 
                        WHERE WorkerUserId = @WorkerId AND OperationType = 'возврат'
                        GROUP BY ToolId
                    )
                    SELECT 
                        i.ToolId,
                        t.Article,
                        t.Name as ToolName,
                        COALESCE(i.IssuedQuantity, 0) - COALESCE(r.ReturnedQuantity, 0) as OnHand
                    FROM Issued i
                    INNER JOIN Tools t ON i.ToolId = t.Id
                    LEFT JOIN Returned r ON i.ToolId = r.ToolId
                    WHERE COALESCE(i.IssuedQuantity, 0) - COALESCE(r.ReturnedQuantity, 0) > 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@WorkerId", workerId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}