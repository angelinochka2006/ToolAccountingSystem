using System;
using System.Data;

namespace ToolAccountingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Tool
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class StorageLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public int ResponsibleUserId { get; set; }
        public string ResponsibleUserName { get; set; }
    }

    public class ToolOperation
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public int StorageLocationId { get; set; }
        public string StorageLocationName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? WorkerUserId { get; set; }
        public string WorkerUserName { get; set; }
        public string OperationType { get; set; }
        public int Quantity { get; set; }
        public DateTime OperationDate { get; set; }
        public string Notes { get; set; }
    }

    public class ToolBalance
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string Article { get; set; }
        public int StorageLocationId { get; set; }
        public string StorageLocationName { get; set; }
        public int Balance { get; set; }
    }
}