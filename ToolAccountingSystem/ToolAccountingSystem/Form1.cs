using System;
using System.Windows.Forms;
using ToolAccountingSystem.Models;

namespace ToolAccountingSystem
{
    public partial class Form1 : Form
    {
        private User currentUser;
        private DatabaseHelper db;

        public Form1(User user)
        {
            InitializeComponent();
            currentUser = user;
            db = new DatabaseHelper();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.файлToolStripMenuItem = new ToolStripMenuItem();
            this.выходToolStripMenuItem = new ToolStripMenuItem();
            this.учётToolStripMenuItem = new ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new ToolStripMenuItem();
            this.местаХраненияToolStripMenuItem = new ToolStripMenuItem();
            this.операцииToolStripMenuItem = new ToolStripMenuItem();
            this.приёмкаСписаниеToolStripMenuItem = new ToolStripMenuItem();
            this.выдачаИнструментаToolStripMenuItem = new ToolStripMenuItem();
            this.возвратИнструментаToolStripMenuItem = new ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new ToolStripMenuItem();
            this.остаткиToolStripMenuItem = new ToolStripMenuItem();
            this.инструментНаРукахToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // menuStrip1
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                this.файлToolStripMenuItem,
                this.учётToolStripMenuItem,
                this.операцииToolStripMenuItem,
                this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // файлToolStripMenuItem
            this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";

            // выходToolStripMenuItem
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new EventHandler(this.выходToolStripMenuItem_Click);

            // учётToolStripMenuItem
            this.учётToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.инструментыToolStripMenuItem,
                this.местаХраненияToolStripMenuItem});
            this.учётToolStripMenuItem.Name = "учётToolStripMenuItem";
            this.учётToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.учётToolStripMenuItem.Text = "Учёт";

            // инструментыToolStripMenuItem
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            this.инструментыToolStripMenuItem.Click += new EventHandler(this.инструментыToolStripMenuItem_Click);

            // местаХраненияToolStripMenuItem
            this.местаХраненияToolStripMenuItem.Name = "местаХраненияToolStripMenuItem";
            this.местаХраненияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.местаХраненияToolStripMenuItem.Text = "Места хранения";
            this.местаХраненияToolStripMenuItem.Click += new EventHandler(this.местаХраненияToolStripMenuItem_Click);

            // операцииToolStripMenuItem
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.приёмкаСписаниеToolStripMenuItem,
                this.выдачаИнструментаToolStripMenuItem,
                this.возвратИнструментаToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.операцииToolStripMenuItem.Text = "Операции";

            // приёмкаСписаниеToolStripMenuItem
            this.приёмкаСписаниеToolStripMenuItem.Name = "приёмкаСписаниеToolStripMenuItem";
            this.приёмкаСписаниеToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.приёмкаСписаниеToolStripMenuItem.Text = "Приёмка/Списание";
            this.приёмкаСписаниеToolStripMenuItem.Click += new EventHandler(this.приёмкаСписаниеToolStripMenuItem_Click);

            // выдачаИнструментаToolStripMenuItem
            this.выдачаИнструментаToolStripMenuItem.Name = "выдачаИнструментаToolStripMenuItem";
            this.выдачаИнструментаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выдачаИнструментаToolStripMenuItem.Text = "Выдача инструмента";
            this.выдачаИнструментаToolStripMenuItem.Click += new EventHandler(this.выдачаИнструментаToolStripMenuItem_Click);

            // возвратИнструментаToolStripMenuItem
            this.возвратИнструментаToolStripMenuItem.Name = "возвратИнструментаToolStripMenuItem";
            this.возвратИнструментаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.возвратИнструментаToolStripMenuItem.Text = "Возврат инструмента";
            this.возвратИнструментаToolStripMenuItem.Click += new EventHandler(this.возвратИнструментаToolStripMenuItem_Click);

            // отчётыToolStripMenuItem
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.остаткиToolStripMenuItem,
                this.инструментНаРукахToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";

            // остаткиToolStripMenuItem
            this.остаткиToolStripMenuItem.Name = "остаткиToolStripMenuItem";
            this.остаткиToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.остаткиToolStripMenuItem.Text = "Остатки";
            this.остаткиToolStripMenuItem.Click += new EventHandler(this.остаткиToolStripMenuItem_Click);

            // инструментНаРукахToolStripMenuItem
            this.инструментНаРукахToolStripMenuItem.Name = "инструментНаРукахToolStripMenuItem";
            this.инструментНаРукахToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.инструментНаРукахToolStripMenuItem.Text = "Инструмент на руках";
            this.инструментНаРукахToolStripMenuItem.Click += new EventHandler(this.инструментНаРукахToolStripMenuItem_Click);

            // statusStrip1
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
                this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Информационная система учёта инструмента";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem учётToolStripMenuItem;
        private ToolStripMenuItem инструментыToolStripMenuItem;
        private ToolStripMenuItem местаХраненияToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem приёмкаСписаниеToolStripMenuItem;
        private ToolStripMenuItem выдачаИнструментаToolStripMenuItem;
        private ToolStripMenuItem возвратИнструментаToolStripMenuItem;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem остаткиToolStripMenuItem;
        private ToolStripMenuItem инструментНаРукахToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;

        private void SetupUI()
        {
            toolStripStatusLabel1.Text = $"Пользователь: {currentUser.FullName} | Роль: {currentUser.RoleName}";

            // Настройка видимости меню в зависимости от роли
            if (currentUser.RoleId == 3) // Рабочий
            {
                учётToolStripMenuItem.Visible = false;
                операцииToolStripMenuItem.Visible = false;
                остаткиToolStripMenuItem.Visible = false;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void инструментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsForm form = new ToolsForm();
            form.ShowDialog();
        }

        private void местаХраненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorageLocationsForm form = new StorageLocationsForm();
            form.ShowDialog();
        }

        private void приёмкаСписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptWriteOffForm form = new ReceiptWriteOffForm(currentUser);
            form.ShowDialog();
        }

        private void выдачаИнструментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueToolForm form = new IssueToolForm(currentUser);
            form.ShowDialog();
        }

        private void возвратИнструментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnToolForm form = new ReturnToolForm(currentUser);
            form.ShowDialog();
        }

        private void остаткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceForm form = new BalanceForm();
            form.ShowDialog();
        }

        private void инструментНаРукахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.RoleId == 3) // Рабочий
            {
                WorkerToolsForm form = new WorkerToolsForm(currentUser.Id);
                form.ShowDialog();
            }
            else
            {
                AllWorkerToolsForm form = new AllWorkerToolsForm();
                form.ShowDialog();
            }
        }
    }
}