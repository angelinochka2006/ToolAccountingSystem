using System;
using System.Data;
using System.Windows.Forms;
using ToolAccountingSystem.Models;

namespace ToolAccountingSystem
{
    public partial class ReceiptWriteOffForm : Form
    {
        private DatabaseHelper db;
        private User currentUser;

        public ReceiptWriteOffForm(User user)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            currentUser = user;
            LoadComboBoxes();
        }

        private void InitializeComponent()
        {
            this.cmbTool = new ComboBox();
            this.cmbStorageLocation = new ComboBox();
            this.numQuantity = new NumericUpDown();
            this.cmbOperationType = new ComboBox();
            this.txtNotes = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // cmbTool
            this.cmbTool.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTool.FormattingEnabled = true;
            this.cmbTool.Location = new System.Drawing.Point(120, 20);
            this.cmbTool.Name = "cmbTool";
            this.cmbTool.Size = new System.Drawing.Size(200, 21);
            this.cmbTool.TabIndex = 0;

            // cmbStorageLocation
            this.cmbStorageLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStorageLocation.FormattingEnabled = true;
            this.cmbStorageLocation.Location = new System.Drawing.Point(120, 50);
            this.cmbStorageLocation.Name = "cmbStorageLocation";
            this.cmbStorageLocation.Size = new System.Drawing.Size(200, 21);
            this.cmbStorageLocation.TabIndex = 1;

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(120, 80);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // cmbOperationType
            this.cmbOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperationType.FormattingEnabled = true;
            this.cmbOperationType.Items.AddRange(new object[] { "приёмка", "списание" });
            this.cmbOperationType.Location = new System.Drawing.Point(120, 110);
            this.cmbOperationType.Name = "cmbOperationType";
            this.cmbOperationType.Size = new System.Drawing.Size(200, 21);
            this.cmbOperationType.TabIndex = 3;

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(120, 140);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(200, 60);
            this.txtNotes.TabIndex = 4;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Инструмент:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Место хранения:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Количество:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип операции:";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Примечание:";

            // ReceiptWriteOffForm
            this.ClientSize = new System.Drawing.Size(344, 251);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cmbOperationType);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbStorageLocation);
            this.Controls.Add(this.cmbTool);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptWriteOffForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Приёмка/Списание инструмента";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ComboBox cmbTool;
        private ComboBox cmbStorageLocation;
        private NumericUpDown numQuantity;
        private ComboBox cmbOperationType;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private void LoadComboBoxes()
        {
            // Загрузка инструментов
            DataTable tools = db.GetTools(1, 1000); // Большое количество для показа всех
            cmbTool.DisplayMember = "Name";
            cmbTool.ValueMember = "Id";
            cmbTool.DataSource = tools;

            // Загрузка мест хранения
            DataTable locations = db.GetStorageLocations();
            cmbStorageLocation.DisplayMember = "Name";
            cmbStorageLocation.ValueMember = "Id";
            cmbStorageLocation.DataSource = locations;

            cmbOperationType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbTool.SelectedValue == null || cmbStorageLocation.SelectedValue == null)
            {
                MessageBox.Show("Выберите инструмент и место хранения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToolOperation operation = new ToolOperation
            {
                ToolId = Convert.ToInt32(cmbTool.SelectedValue),
                StorageLocationId = Convert.ToInt32(cmbStorageLocation.SelectedValue),
                UserId = currentUser.Id,
                OperationType = cmbOperationType.SelectedItem.ToString(),
                Quantity = Convert.ToInt32(numQuantity.Value),
                Notes = txtNotes.Text
            };

            if (db.AddToolOperation(operation))
            {
                MessageBox.Show("Операция успешно сохранена", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении операции", "Ошибка",
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