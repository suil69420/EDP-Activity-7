using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class StaffDialog : Form
    {
        public int StaffId { get; set; }
        public bool IsNewRecord { get; set; }

        public StaffDialog()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this, dialog: true);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyLabel(lblFirstName);
            UiTheme.ApplyLabel(lblLastName);
            UiTheme.ApplyLabel(lblContactNumber);
            UiTheme.ApplyTextBox(txtFirstName);
            UiTheme.ApplyTextBox(txtLastName);
            UiTheme.ApplyTextBox(txtContactNumber);
            UiTheme.ApplyPrimaryButton(btnSave);
            UiTheme.ApplySecondaryButton(btnCancel);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            IsNewRecord = true;
        }

        private void StaffDialog_Load(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                LoadStaffData();
            }
        }

        private void LoadStaffData()
        {
            var sql = "SELECT * FROM staff WHERE staff_id = @id";
            var dt = DBHelper.ExecuteQuery(sql, new MySqlParameter("@id", StaffId));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtFirstName.Text = row["first_name"].ToString();
                txtLastName.Text = row["last_name"].ToString();
                txtContactNumber.Text = row["staff_contact_num"].ToString();
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
                    InsertStaff();
                }
                else
                {
                    UpdateStaff();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertStaff()
        {
            var nextId = Convert.ToInt32(DBHelper.ExecuteScalar("SELECT COALESCE(MAX(staff_id), 0) + 1 FROM staff"));
            var sql = "INSERT INTO staff (staff_id, first_name, last_name, staff_contact_num) VALUES (@id, @fn, @ln, @contact)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", nextId),
                new MySqlParameter("@fn", txtFirstName.Text.Trim()),
                new MySqlParameter("@ln", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()));
        }

        private void UpdateStaff()
        {
            var sql = "UPDATE staff SET first_name = @fn, last_name = @ln, staff_contact_num = @contact WHERE staff_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@fn", txtFirstName.Text.Trim()),
                new MySqlParameter("@ln", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()),
                new MySqlParameter("@id", StaffId));

            RecordLockManager.UnlockRecord("staff", StaffId);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Contact number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                RecordLockManager.UnlockRecord("staff", StaffId);
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 15);
            this.lblFirstName.Text = "First Name";

            this.txtFirstName.Location = new System.Drawing.Point(120, 12);
            this.txtFirstName.Size = new System.Drawing.Size(250, 22);

            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(15, 45);
            this.lblLastName.Text = "Last Name";

            this.txtLastName.Location = new System.Drawing.Point(120, 42);
            this.txtLastName.Size = new System.Drawing.Size(250, 22);

            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Location = new System.Drawing.Point(15, 75);
            this.lblContactNumber.Text = "Contact Number";

            this.txtContactNumber.Location = new System.Drawing.Point(120, 72);
            this.txtContactNumber.Size = new System.Drawing.Size(250, 22);

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
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.lblContactNumber);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Name = "StaffDialog";
            this.Text = "Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.StaffDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblContactNumber;
    }
}
