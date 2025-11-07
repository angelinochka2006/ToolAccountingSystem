using System;
using System.Data;
using System.Windows.Forms;

namespace ToolAccountingSystem
{
    public partial class BalanceForm : Form
    {
        private DatabaseHelper db;

        public BalanceForm()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadBalance();
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbStorageLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbStorageLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(600, 300);
            this.dataGridView1.TabIndex = 0;

            // cmbStorageLocation
            this.cmbStorageLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStorageLocation.FormattingEnabled = true;
            this.cmbStorageLocation.Location = new System.Drawing.Point(120, 15);
            this.cmbStorageLocation.Name = "cmbStorageLocation";
            this.cmbStorageLocation.Size = new System.Drawing.Size(200, 21);
            this.cmbStorageLocation.TabIndex = 1;
            this.cmbStorageLocation.SelectedIndexChanged += new System.EventHandler(this.cmbStorageLocation_SelectedIndexChanged);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Место хранения:";

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(330, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // BalanceForm
            this.ClientSize = new System.Drawing.Size(624, 362);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStorageLocation);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BalanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Остатки инструмента";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadBalance()
        {
            // Загрузка мест хранения
            DataTable locations = db.GetStorageLocations();
            DataRow allRow = locations.NewRow();
            allRow["Id"] = 0;
            allRow["Name"] = "Все места хранения";
            locations.Rows.InsertAt(allRow, 0);

            cmbStorageLocation.DisplayMember = "Name";
            cmbStorageLocation.ValueMember = "Id";
            cmbStorageLocation.DataSource = locations;

            LoadBalanceData();
        }

        private void LoadBalanceData()
        {
            int storageLocationId = 0;
            if (cmbStorageLocation.SelectedValue != null)
            {
                storageLocationId = Convert.ToInt32(cmbStorageLocation.SelectedValue);
            }

            DataTable balance = db.GetToolBalance(storageLocationId);
            dataGridView1.DataSource = balance;
        }

        private void cmbStorageLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBalanceData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBalanceData();
        }
    }
}