using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class VaccineDialog : Form
    {
        public int VaccineId { get; set; }
        public bool IsNewRecord { get; set; }

        public VaccineDialog()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this, dialog: true);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyLabel(lblVaccineName);
            UiTheme.ApplyLabel(lblDescription);
            UiTheme.ApplyTextBox(txtVaccineName);
            UiTheme.ApplyDatePicker(dtpExpiryDate);
            UiTheme.ApplyPrimaryButton(btnSave);
            UiTheme.ApplySecondaryButton(btnCancel);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            IsNewRecord = true;
        }

        private void VaccineDialog_Load(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                LoadVaccineData();
            }
        }

        private void LoadVaccineData()
        {
            var sql = "SELECT * FROM vaccine WHERE vaccine_id = @id";
            var dt = DBHelper.ExecuteQuery(sql, new MySqlParameter("@id", VaccineId));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtVaccineName.Text = row["vaccine_name"].ToString();
                if (dt.Columns.Contains("vaccine_expiry_date") && row["vaccine_expiry_date"] != DBNull.Value)
                {
                    dtpExpiryDate.Value = (DateTime)row["vaccine_expiry_date"];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                if (IsNewRecord)
                {
                    InsertVaccine();
                }
                else
                {
                    UpdateVaccine();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving vaccine: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertVaccine()
        {
            var nextId = Convert.ToInt32(DBHelper.ExecuteScalar("SELECT COALESCE(MAX(vaccine_id), 0) + 1 FROM vaccine"));
            var sql = "INSERT INTO vaccine (vaccine_id, vaccine_name, vaccine_expiry_date) VALUES (@id, @name, @expiry_date)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", nextId),
                new MySqlParameter("@name", txtVaccineName.Text.Trim()),
                new MySqlParameter("@expiry_date", dtpExpiryDate.Value.Date));
        }

        private void UpdateVaccine()
        {
            var sql = "UPDATE vaccine SET vaccine_name = @name, vaccine_expiry_date = @expiry_date WHERE vaccine_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@name", txtVaccineName.Text.Trim()),
                new MySqlParameter("@expiry_date", dtpExpiryDate.Value.Date),
                new MySqlParameter("@id", VaccineId));

            RecordLockManager.UnlockRecord("vaccine", VaccineId);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtVaccineName.Text))
            {
                MessageBox.Show("Vaccine name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                RecordLockManager.UnlockRecord("vaccine", VaccineId);
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            this.txtVaccineName = new System.Windows.Forms.TextBox();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblVaccineName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblVaccineName.AutoSize = true;
            this.lblVaccineName.Location = new System.Drawing.Point(15, 15);
            this.lblVaccineName.Text = "Vaccine Name";

            this.txtVaccineName.Location = new System.Drawing.Point(120, 12);
            this.txtVaccineName.Size = new System.Drawing.Size(250, 22);

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 45);
            this.lblDescription.Text = "Expiry Date";

            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(120, 42);
            this.dtpExpiryDate.Size = new System.Drawing.Size(250, 22);

            this.btnSave.Location = new System.Drawing.Point(195, 110);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(285, 110);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtVaccineName);
            this.Controls.Add(this.lblVaccineName);
            this.Name = "VaccineDialog";
            this.Text = "Vaccine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.VaccineDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtVaccineName;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblVaccineName;
        private System.Windows.Forms.Label lblDescription;
    }
}
