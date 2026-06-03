using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class PersonForm : Form
    {
        public PersonForm()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyDataGrid(dgvPersons);
            UiTheme.ApplyLabel(lblPersonId);
            UiTheme.ApplyLabel(lblFirstName);
            UiTheme.ApplyLabel(lblLastName);
            UiTheme.ApplyLabel(lblContactNumber);
            UiTheme.ApplyTextBox(txtPersonId);
            UiTheme.ApplyTextBox(txtFirstName);
            UiTheme.ApplyTextBox(txtLastName);
            UiTheme.ApplyTextBox(txtContactNumber);
            UiTheme.ApplyTextBox(txtSearchPerson);
            UiTheme.ApplyPrimaryButton(btnAddPerson);
            UiTheme.ApplySecondaryButton(btnUpdatePerson);
            UiTheme.ApplySecondaryButton(btnDeletePerson);
            UiTheme.ApplySecondaryButton(btnSearchPerson);
            LoadPersons();
        }

        private void LoadPersons(string filterSql = null, params MySqlParameter[] parameters)
        {
            var sql = "SELECT person_id, first_name, last_name, person_contact_num FROM person";
            if (!string.IsNullOrWhiteSpace(filterSql))
            {
                sql += " WHERE " + filterSql;
            }

            personBindingSource.DataSource = DBHelper.ExecuteQuery(sql, parameters);
            dgvPersons.DataSource = personBindingSource;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPersonId.Text.Trim(), out var id))
            {
                MessageBox.Show("Enter a valid Person ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sql = "INSERT INTO person (person_id, first_name, last_name, person_contact_num) VALUES (@id, @first, @last, @contact)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@first", txtFirstName.Text.Trim()),
                new MySqlParameter("@last", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()));

            LoadPersons();
            ClearForm();
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPersonId.Text.Trim(), out var id)) return;

            var sql = "UPDATE person SET first_name = @first, last_name = @last, person_contact_num = @contact WHERE person_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@first", txtFirstName.Text.Trim()),
                new MySqlParameter("@last", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()),
                new MySqlParameter("@id", id));

            LoadPersons();
        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPersonId.Text.Trim(), out var id)) return;

            var sql = "DELETE FROM person WHERE person_id = @id";
            DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
            LoadPersons();
            ClearForm();
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            var search = txtSearchPerson.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadPersons();
                return;
            }

            if (int.TryParse(search, out var id))
            {
                LoadPersons("person_id = @id", new MySqlParameter("@id", id));
                return;
            }

            var queryValue = $"%{search}%";
            LoadPersons("first_name LIKE @q OR last_name LIKE @q OR person_contact_num LIKE @q", new MySqlParameter("@q", queryValue));
        }

        private void dgvPersons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersons.SelectedRows.Count == 0) return;
            var row = (dgvPersons.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
            if (row == null) return;
            txtPersonId.Text = row.Field<int>("person_id").ToString();
            txtFirstName.Text = row.Field<string>("first_name");
            txtLastName.Text = row.Field<string>("last_name");
            txtContactNumber.Text = row.Field<string>("person_contact_num");
        }

        private void ClearForm()
        {
            txtPersonId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtSearchPerson.Clear();
        }
    }
}
