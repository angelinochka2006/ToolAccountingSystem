using System;
using System.Data;
using System.Windows.Forms;

namespace ToolAccountingSystem
{
    public partial class StorageLocationsForm : Form
    {
        private DatabaseHelper db;

        public StorageLocationsForm()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadStorageLocations();
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(600, 300);
            this.dataGridView1.TabIndex = 0;

            // StorageLocationsForm
            this.ClientSize = new System.Drawing.Size(624, 324);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageLocationsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Места хранения";
            this.ResumeLayout(false);
        }

        private DataGridView dataGridView1;

        private void LoadStorageLocations()
        {
            DataTable locations = db.GetStorageLocations();
            dataGridView1.DataSource = locations;
        }
    }
}