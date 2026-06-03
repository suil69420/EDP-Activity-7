using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class VaccinationDialog : Form
    {
        public int RecordId { get; set; }
        public bool IsNewRecord { get; set; }

        public VaccinationDialog()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this, dialog: true);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyLabel(lblPerson);
            UiTheme.ApplyLabel(lblStaff);
            UiTheme.ApplyLabel(lblVaccine);
            UiTheme.ApplyLabel(lblDose);
            UiTheme.ApplyLabel(lblDate);
            UiTheme.ApplyLabel(lblRoom);
            UiTheme.ApplyComboBox(comboPerson);
            UiTheme.ApplyComboBox(comboStaff);
            UiTheme.ApplyComboBox(comboVaccine);
            UiTheme.ApplyTextBox(txtDose);
            UiTheme.ApplyDatePicker(dtpDate);
            UiTheme.ApplyComboBox(comboRoom);
            UiTheme.ApplyPrimaryButton(btnSave);
            UiTheme.ApplySecondaryButton(btnCancel);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            IsNewRecord = true;
            LoadLookupData();
        }

        private void VaccinationDialog_Load(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                LoadVaccinationData();
            }
        }

        private void LoadLookupData()
        {
            comboPerson.DataSource = DBHelper.ExecuteQuery("SELECT person_id AS id, CONCAT(first_name, ' ', last_name) AS display_name FROM person");
            comboPerson.DisplayMember = "display_name";
            comboPerson.ValueMember = "id";

            comboStaff.DataSource = DBHelper.ExecuteQuery("SELECT staff_id AS id, CONCAT(first_name, ' ', last_name) AS display_name FROM staff");
            comboStaff.DisplayMember = "display_name";
            comboStaff.ValueMember = "id";

            comboVaccine.DataSource = DBHelper.ExecuteQuery("SELECT vaccine_id AS id, vaccine_name AS display_name FROM vaccine");
            comboVaccine.DisplayMember = "display_name";
            comboVaccine.ValueMember = "id";

            comboRoom.DataSource = DBHelper.ExecuteQuery("SELECT room_id AS id, room_name AS display_name FROM room");
            comboRoom.DisplayMember = "display_name";
            comboRoom.ValueMember = "id";
        }

        private void LoadVaccinationData()
        {
            var sql = "SELECT person_id, staff_id, vaccine_id, vaccination_dose, vaccination_date, room_id FROM vaccination_record WHERE record_id = @id";
            var dt = DBHelper.ExecuteQuery(sql, new MySqlParameter("@id", RecordId));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                comboPerson.SelectedValue = row["person_id"];
                comboStaff.SelectedValue = row["staff_id"];
                comboVaccine.SelectedValue = row["vaccine_id"];
                txtDose.Text = row["vaccination_dose"].ToString();
                dtpDate.Value = (DateTime)row["vaccination_date"];
                comboRoom.SelectedValue = row["room_id"];
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
                    InsertVaccination();
                }
                else
                {
                    UpdateVaccination();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving vaccination record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertVaccination()
        {
            var nextId = Convert.ToInt32(DBHelper.ExecuteScalar("SELECT COALESCE(MAX(record_id), 0) + 1 FROM vaccination_record"));

            using var cmd = new MySqlCommand("add_vaccination_record", DBConnection.GetConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_record_id", nextId);
            cmd.Parameters.AddWithValue("@p_person_id", comboPerson.SelectedValue);
            cmd.Parameters.AddWithValue("@p_staff_id", comboStaff.SelectedValue);
            cmd.Parameters.AddWithValue("@p_vaccine_id", comboVaccine.SelectedValue);
            cmd.Parameters.AddWithValue("@p_dose", txtDose.Text.Trim());
            cmd.Parameters.AddWithValue("@p_date", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@p_room_id", comboRoom.SelectedValue);
            cmd.ExecuteNonQuery();
        }

        private void UpdateVaccination()
        {
            var sql = "UPDATE vaccination_record SET person_id = @person_id, staff_id = @staff_id, vaccine_id = @vaccine_id, vaccination_dose = @dose, vaccination_date = @date, room_id = @room_id WHERE record_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@person_id", comboPerson.SelectedValue),
                new MySqlParameter("@staff_id", comboStaff.SelectedValue),
                new MySqlParameter("@vaccine_id", comboVaccine.SelectedValue),
                new MySqlParameter("@dose", txtDose.Text.Trim()),
                new MySqlParameter("@date", dtpDate.Value.Date),
                new MySqlParameter("@room_id", comboRoom.SelectedValue),
                new MySqlParameter("@id", RecordId));

            RecordLockManager.UnlockRecord("vaccination_record", RecordId);
        }

        private bool ValidateForm()
        {
            if (comboPerson.SelectedValue == null)
            {
                MessageBox.Show("Please select a person.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboStaff.SelectedValue == null)
            {
                MessageBox.Show("Please select staff.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboVaccine.SelectedValue == null)
            {
                MessageBox.Show("Please select a vaccine.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDose.Text))
            {
                MessageBox.Show("Dose is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboRoom.SelectedValue == null)
            {
                MessageBox.Show("Please select a room.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                RecordLockManager.UnlockRecord("vaccination_record", RecordId);
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            this.comboPerson = new System.Windows.Forms.ComboBox();
            this.comboStaff = new System.Windows.Forms.ComboBox();
            this.comboVaccine = new System.Windows.Forms.ComboBox();
            this.txtDose = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.comboRoom = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblVaccine = new System.Windows.Forms.Label();
            this.lblDose = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(15, 15);
            this.lblPerson.Text = "Person";

            this.comboPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPerson.Location = new System.Drawing.Point(120, 12);
            this.comboPerson.Size = new System.Drawing.Size(250, 24);

            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(15, 45);
            this.lblStaff.Text = "Staff";

            this.comboStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStaff.Location = new System.Drawing.Point(120, 42);
            this.comboStaff.Size = new System.Drawing.Size(250, 24);

            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Location = new System.Drawing.Point(15, 75);
            this.lblVaccine.Text = "Vaccine";

            this.comboVaccine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVaccine.Location = new System.Drawing.Point(120, 72);
            this.comboVaccine.Size = new System.Drawing.Size(250, 24);

            this.lblDose.AutoSize = true;
            this.lblDose.Location = new System.Drawing.Point(15, 105);
            this.lblDose.Text = "Dose";

            this.txtDose.Location = new System.Drawing.Point(120, 102);
            this.txtDose.Size = new System.Drawing.Size(250, 22);

            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(15, 135);
            this.lblDate.Text = "Date";

            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(120, 132);
            this.dtpDate.Size = new System.Drawing.Size(250, 22);

            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(15, 165);
            this.lblRoom.Text = "Room";

            this.comboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoom.Location = new System.Drawing.Point(120, 162);
            this.comboRoom.Size = new System.Drawing.Size(250, 24);

            this.btnSave.Location = new System.Drawing.Point(195, 200);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(285, 200);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDose);
            this.Controls.Add(this.lblDose);
            this.Controls.Add(this.comboVaccine);
            this.Controls.Add(this.lblVaccine);
            this.Controls.Add(this.comboStaff);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.comboPerson);
            this.Controls.Add(this.lblPerson);
            this.Name = "VaccinationDialog";
            this.Text = "Vaccination Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.VaccinationDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboPerson;
        private System.Windows.Forms.ComboBox comboStaff;
        private System.Windows.Forms.ComboBox comboVaccine;
        private System.Windows.Forms.TextBox txtDose;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox comboRoom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.Label lblDose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRoom;
    }
}
