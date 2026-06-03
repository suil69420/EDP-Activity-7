using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class VaccinationForm : Form
    {
        public VaccinationForm()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyDataGrid(dgvVaccinationRecords);
            UiTheme.ApplyLabel(lblRecordId);
            UiTheme.ApplyLabel(lblPerson);
            UiTheme.ApplyLabel(lblStaff);
            UiTheme.ApplyLabel(lblVaccine);
            UiTheme.ApplyLabel(lblDose);
            UiTheme.ApplyLabel(lblDate);
            UiTheme.ApplyLabel(lblRoom);
            UiTheme.ApplyLabel(lblDoseCount);
            UiTheme.ApplyLabel(lblDoseCountValue);
            UiTheme.ApplyTextBox(txtRecordId);
            UiTheme.ApplyComboBox(comboPerson);
            UiTheme.ApplyComboBox(comboStaff);
            UiTheme.ApplyComboBox(comboVaccine);
            UiTheme.ApplyTextBox(txtDose);
            UiTheme.ApplyDatePicker(dtpDate);
            UiTheme.ApplyComboBox(comboRoom);
            UiTheme.ApplyTextBox(txtSearchRecord);
            UiTheme.ApplyPrimaryButton(btnAddRecord);
            UiTheme.ApplySecondaryButton(btnUpdateRecord);
            UiTheme.ApplySecondaryButton(btnDeleteRecord);
            UiTheme.ApplySecondaryButton(btnShowDoseCount);
            UiTheme.ApplySecondaryButton(btnSearchRecord);
            LoadLookupData();
            LoadVaccinationRecords();
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

        private void LoadVaccinationRecords(string filterSql = null, params MySqlParameter[] parameters)
        {
            var sql = @"SELECT vr.record_id,
                           CONCAT(p.first_name, ' ', p.last_name) AS person,
                           CONCAT(s.first_name, ' ', s.last_name) AS staff,
                           v.vaccine_name AS vaccine,
                           vr.vaccination_dose,
                           vr.vaccination_date,
                           r.room_name AS room
                        FROM vaccination_record vr
                        JOIN person p ON vr.person_id = p.person_id
                        JOIN staff s ON vr.staff_id = s.staff_id
                        JOIN vaccine v ON vr.vaccine_id = v.vaccine_id
                        JOIN room r ON vr.room_id = r.room_id";

            if (!string.IsNullOrWhiteSpace(filterSql))
            {
                sql += " WHERE " + filterSql;
            }

            vaccinationBindingSource.DataSource = DBHelper.ExecuteQuery(sql, parameters);
            dgvVaccinationRecords.DataSource = vaccinationBindingSource;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRecordId.Text.Trim(), out var id))
            {
                MessageBox.Show("Enter a valid Record ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var cmd = new MySqlCommand("add_vaccination_record", DBConnection.GetConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_record_id", id);
            cmd.Parameters.AddWithValue("@p_person_id", comboPerson.SelectedValue);
            cmd.Parameters.AddWithValue("@p_staff_id", comboStaff.SelectedValue);
            cmd.Parameters.AddWithValue("@p_vaccine_id", comboVaccine.SelectedValue);
            cmd.Parameters.AddWithValue("@p_dose", txtDose.Text.Trim());
            cmd.Parameters.AddWithValue("@p_date", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@p_room_id", comboRoom.SelectedValue);
            cmd.ExecuteNonQuery();

            LoadVaccinationRecords();
            ClearForm();
        }

        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRecordId.Text.Trim(), out var id)) return;

            var sql = "UPDATE vaccination_record SET person_id = @person_id, staff_id = @staff_id, vaccine_id = @vaccine_id, vaccination_dose = @dose, vaccination_date = @date, room_id = @room_id WHERE record_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@person_id", comboPerson.SelectedValue),
                new MySqlParameter("@staff_id", comboStaff.SelectedValue),
                new MySqlParameter("@vaccine_id", comboVaccine.SelectedValue),
                new MySqlParameter("@dose", txtDose.Text.Trim()),
                new MySqlParameter("@date", dtpDate.Value.Date),
                new MySqlParameter("@room_id", comboRoom.SelectedValue),
                new MySqlParameter("@id", id));

            LoadVaccinationRecords();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRecordId.Text.Trim(), out var id)) return;

            var sql = "DELETE FROM vaccination_record WHERE record_id = @id";
            DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
            LoadVaccinationRecords();
            ClearForm();
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            var search = txtSearchRecord.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadVaccinationRecords();
                return;
            }

            if (int.TryParse(search, out var id))
            {
                LoadVaccinationRecords("vr.record_id = @id", new MySqlParameter("@id", id));
                return;
            }

            var queryValue = $"%{search}%";
            LoadVaccinationRecords(
                "CONCAT(p.first_name, ' ', p.last_name) LIKE @q OR CONCAT(s.first_name, ' ', s.last_name) LIKE @q OR v.vaccine_name LIKE @q OR r.room_name LIKE @q OR vr.vaccination_dose LIKE @q",
                new MySqlParameter("@q", queryValue));
        }

        private void btnShowDoseCount_Click(object sender, EventArgs e)
        {
            if (comboPerson.SelectedValue == null) return;

            var personId = comboPerson.SelectedValue;
            var result = DBHelper.ExecuteScalar("SELECT patient_dose_count(@p_id)", new MySqlParameter("@p_id", personId));
            lblDoseCountValue.Text = result?.ToString() ?? "0";
        }

        private void dgvVaccinationRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVaccinationRecords.SelectedRows.Count == 0) return;
            var viewRow = (dgvVaccinationRecords.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
            if (viewRow == null) return;

            txtRecordId.Text = viewRow.Field<int>("record_id").ToString();
            txtDose.Text = viewRow.Field<string>("vaccination_dose");
            dtpDate.Value = viewRow.Field<DateTime>("vaccination_date");

            var recordId = viewRow.Field<int>("record_id");
            var sourceRow = DBHelper.ExecuteQuery("SELECT person_id, staff_id, vaccine_id, room_id FROM vaccination_record WHERE record_id = @id", new MySqlParameter("@id", recordId));
            if (sourceRow.Rows.Count == 0) return;

            comboPerson.SelectedValue = sourceRow.Rows[0].Field<int>("person_id");
            comboStaff.SelectedValue = sourceRow.Rows[0].Field<int>("staff_id");
            comboVaccine.SelectedValue = sourceRow.Rows[0].Field<int>("vaccine_id");
            comboRoom.SelectedValue = sourceRow.Rows[0].Field<int>("room_id");
        }

        private void ClearForm()
        {
            txtRecordId.Clear();
            txtDose.Clear();
            dtpDate.Value = DateTime.Today;
            txtSearchRecord.Clear();
            lblDoseCountValue.Text = "0";
        }
    }
}
