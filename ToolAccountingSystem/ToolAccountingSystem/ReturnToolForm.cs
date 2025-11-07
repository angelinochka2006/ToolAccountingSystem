using System;
using System.Data;
using System.Windows.Forms;
using ToolAccountingSystem.Models;

namespace ToolAccountingSystem
{
    public partial class ReturnToolForm : Form
    {
        private DatabaseHelper db;
        private User currentUser;

        public ReturnToolForm(User user)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            currentUser = user;
            LoadComboBoxes();
        }

        private void InitializeComponent()
        {
            this.cmbWorker = new ComboBox();
            this.cmbTool = new ComboBox();
            this.numQuantity = new NumericUpDown();
            this.txtNotes = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.lblMaxQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // cmbWorker
            this.cmbWorker.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWorker.FormattingEnabled = true;
            this.cmbWorker.Location = new System.Drawing.Point(120, 20);
            this.cmbWorker.Name = "cmbWorker";
            this.cmbWorker.Size = new System.Drawing.Size(200, 21);
            this.cmbWorker.TabIndex = 0;
            this.cmbWorker.SelectedIndexChanged += new EventHandler(this.cmbWorker_SelectedIndexChanged);

            // cmbTool
            this.cmbTool.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTool.FormattingEnabled = true;
            this.cmbTool.Location = new System.Drawing.Point(120, 50);
            this.cmbTool.Name = "cmbTool";
            this.cmbTool.Size = new System.Drawing.Size(200, 21);
            this.cmbTool.TabIndex = 1;
            this.cmbTool.SelectedIndexChanged += new EventHandler(this.cmbTool_SelectedIndexChanged);

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(120, 110);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(120, 140);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(200, 60);
            this.txtNotes.TabIndex = 3;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Вернуть";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Рабочий:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Инструмент:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Примечание:";

            // lblMaxQuantity
            this.lblMaxQuantity.AutoSize = true;
            this.lblMaxQuantity.Location = new System.Drawing.Point(20, 83);
            this.lblMaxQuantity.Name = "lblMaxQuantity";
            this.lblMaxQuantity.Size = new System.Drawing.Size(118, 13);
            this.lblMaxQuantity.TabIndex = 10;
            this.lblMaxQuantity.Text = "Максимум к возврату: ";

            // ReturnToolForm
            this.ClientSize = new System.Drawing.Size(344, 251);
            this.Controls.Add(this.lblMaxQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbTool);
            this.Controls.Add(this.cmbWorker);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnToolForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Возврат инструмента";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ComboBox cmbWorker;
        private ComboBox cmbTool;
        private NumericUpDown numQuantity;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblMaxQuantity;
        private DataTable workerTools;

        private void LoadComboBoxes()
        {
            // Загрузка рабочих
            DataTable workers = db.GetUsersByRole(3);
            cmbWorker.DisplayMember = "FullName";
            cmbWorker.ValueMember = "Id";
            cmbWorker.DataSource = workers;
        }

        private void cmbWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWorker.SelectedValue != null)
            {
                int workerId = Convert.ToInt32(cmbWorker.SelectedValue);
                workerTools = db.GetWorkerTools(workerId);

                cmbTool.DisplayMember = "ToolName";
                cmbTool.ValueMember = "ToolId";
                cmbTool.DataSource = workerTools;

                if (workerTools.Rows.Count > 0)
                {
                    cmbTool_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void cmbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTool.SelectedValue != null && workerTools != null)
            {
                int toolId = Convert.ToInt32(cmbTool.SelectedValue);
                foreach (DataRow row in workerTools.Rows)
                {
                    if (Convert.ToInt32(row["ToolId"]) == toolId)
                    {
                        int onHand = Convert.ToInt32(row["OnHand"]);
                        lblMaxQuantity.Text = $"Максимум к возврату: {onHand}";
                        numQuantity.Maximum = onHand;
                        numQuantity.Value = Math.Min(numQuantity.Value, onHand);
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbWorker.SelectedValue == null || cmbTool.SelectedValue == null)
            {
                MessageBox.Show("Выберите рабочего и инструмент", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Для возврата указываем текущее место хранения как основное (можно добавить выбор)
            DataTable locations = db.GetStorageLocations();
            int mainStorageId = 1; // Основной склад по умолчанию

            ToolOperation operation = new ToolOperation
            {
                ToolId = Convert.ToInt32(cmbTool.SelectedValue),
                StorageLocationId = mainStorageId,
                UserId = currentUser.Id,
                WorkerUserId = Convert.ToInt32(cmbWorker.SelectedValue),
                OperationType = "возврат",
                Quantity = Convert.ToInt32(numQuantity.Value),
                Notes = txtNotes.Text
            };

            if (db.AddToolOperation(operation))
            {
                MessageBox.Show("Инструмент успешно возвращен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при возврате инструмента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}