using System;
using System.Data;
using System.Windows.Forms;

namespace ToolAccountingSystem
{
    public partial class WorkerToolsForm : Form
    {
        private DatabaseHelper db;
        private int workerId;

        public WorkerToolsForm(int workerId)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.workerId = workerId;
            LoadWorkerTools();
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

            // WorkerToolsForm
            this.ClientSize = new System.Drawing.Size(624, 324);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkerToolsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Инструмент на руках";
            this.ResumeLayout(false);
        }

        private DataGridView dataGridView1;

        private void LoadWorkerTools()
        {
            DataTable tools = db.GetWorkerTools(workerId);
            dataGridView1.DataSource = tools;
        }
    }

    public partial class AllWorkerToolsForm : Form
    {
        private DatabaseHelper db;

        public AllWorkerToolsForm()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadAllWorkerTools();
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

            // AllWorkerToolsForm
            this.ClientSize = new System.Drawing.Size(624, 324);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllWorkerToolsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Инструмент у всех рабочих";
            this.ResumeLayout(false);
        }

        private DataGridView dataGridView1;

        private void LoadAllWorkerTools()
        {
            // Здесь можно реализовать загрузку инструмента у всех рабочих
            // Для простоты покажем сообщение
            MessageBox.Show("Здесь будет отображен инструмент у всех рабочих", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}