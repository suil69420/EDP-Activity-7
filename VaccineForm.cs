using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class VaccineForm : Form
    {
        public VaccineForm()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyDataGrid(dgvVaccines);
            UiTheme.ApplyLabel(lblVaccineId);
            UiTheme.ApplyLabel(lblVaccineName);
            UiTheme.ApplyLabel(lblExpiryDate);
            UiTheme.ApplyTextBox(txtVaccineId);
            UiTheme.ApplyTextBox(txtVaccineName);
            UiTheme.ApplyDatePicker(dtpExpiryDate);
            UiTheme.ApplyTextBox(txtSearchVaccine);
            UiTheme.ApplyPrimaryButton(btnAddVaccine);
            UiTheme.ApplySecondaryButton(btnUpdateVaccine);
            UiTheme.ApplySecondaryButton(btnDeleteVaccine);
            UiTheme.ApplySecondaryButton(btnSearchVaccine);
            LoadVaccines();
        }

        private void LoadVaccines(string filterSql = null, params MySqlParameter[] parameters)
        {
            var sql = "SELECT vaccine_id, vaccine_name, vaccine_expiry_date FROM vaccine";
            if (!string.IsNullOrWhiteSpace(filterSql))
            {
                sql += " WHERE " + filterSql;
            }

            vaccineBindingSource.DataSource = DBHelper.ExecuteQuery(sql, parameters);
            dgvVaccines.DataSource = vaccineBindingSource;
        }

        private void btnAddVaccine_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtVaccineId.Text.Trim(), out var id))
            {
                MessageBox.Show("Enter a valid Vaccine ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sql = "INSERT INTO vaccine (vaccine_id, vaccine_name, vaccine_expiry_date) VALUES (@id, @name, @expiry_date)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@name", txtVaccineName.Text.Trim()),
                new MySqlParameter("@expiry_date", dtpExpiryDate.Value.Date));

            LoadVaccines();
            ClearForm();
        }

        private void btnUpdateVaccine_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtVaccineId.Text.Trim(), out var id)) return;

            var sql = "UPDATE vaccine SET vaccine_name = @name, vaccine_expiry_date = @expiry_date WHERE vaccine_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@name", txtVaccineName.Text.Trim()),
                new MySqlParameter("@expiry_date", dtpExpiryDate.Value.Date),
                new MySqlParameter("@id", id));

            LoadVaccines();
        }

        private void btnDeleteVaccine_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtVaccineId.Text.Trim(), out var id)) return;

            var sql = "DELETE FROM vaccine WHERE vaccine_id = @id";
            DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
            LoadVaccines();
            ClearForm();
        }

        private void btnSearchVaccine_Click(object sender, EventArgs e)
        {
            var search = txtSearchVaccine.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadVaccines();
                return;
            }

            if (int.TryParse(search, out var id))
            {
                LoadVaccines("vaccine_id = @id", new MySqlParameter("@id", id));
                return;
            }

            var queryValue = $"%{search}%";
            LoadVaccines("vaccine_name LIKE @q", new MySqlParameter("@q", queryValue));
        }

        private void dgvVaccines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVaccines.SelectedRows.Count == 0) return;
            var row = (dgvVaccines.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
            if (row == null) return;
            txtVaccineId.Text = row.Field<int>("vaccine_id").ToString();
            txtVaccineName.Text = row.Field<string>("vaccine_name");
            dtpExpiryDate.Value = row.Field<DateTime>("vaccine_expiry_date");
        }

        private void ClearForm()
        {
            txtVaccineId.Clear();
            txtVaccineName.Clear();
            dtpExpiryDate.Value = DateTime.Today;
            txtSearchVaccine.Clear();
        }
    }
}
