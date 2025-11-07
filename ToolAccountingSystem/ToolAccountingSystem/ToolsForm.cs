using System;
using System.Data;
using System.Windows.Forms;

namespace ToolAccountingSystem
{
    public partial class ToolsForm : Form
    {
        private DatabaseHelper db;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;

        public ToolsForm()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadTools();
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.btnPrevious = new Button();
            this.btnNext = new Button();
            this.lblPageInfo = new Label();
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

            // btnPrevious
            this.btnPrevious.Location = new System.Drawing.Point(12, 325);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new EventHandler(this.btnPrevious_Click);

            // btnNext
            this.btnNext.Location = new System.Drawing.Point(93, 325);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Вперёд";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new EventHandler(this.btnNext_Click);

            // lblPageInfo
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(174, 330);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(35, 13);
            this.lblPageInfo.TabIndex = 3;

            // ToolsForm
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Инструменты";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dataGridView1;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblPageInfo;

        private void LoadTools()
        {
            DataTable tools = db.GetTools(currentPage, pageSize);
            totalRecords = db.GetToolsCount();

            dataGridView1.DataSource = tools;
            UpdatePaginationInfo();
        }

        private void UpdatePaginationInfo()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPageInfo.Text = $"Страница {currentPage} из {totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadTools();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadTools();
            }
        }
    }
}