using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyDataGrid(dgvStaff);
            UiTheme.ApplyLabel(lblStaffId);
            UiTheme.ApplyLabel(lblFirstName);
            UiTheme.ApplyLabel(lblLastName);
            UiTheme.ApplyLabel(lblContactNumber);
            UiTheme.ApplyTextBox(txtStaffId);
            UiTheme.ApplyTextBox(txtFirstName);
            UiTheme.ApplyTextBox(txtLastName);
            UiTheme.ApplyTextBox(txtContactNumber);
            UiTheme.ApplyTextBox(txtSearchStaff);
            UiTheme.ApplyPrimaryButton(btnAddStaff);
            UiTheme.ApplySecondaryButton(btnUpdateStaff);
            UiTheme.ApplySecondaryButton(btnDeleteStaff);
            UiTheme.ApplySecondaryButton(btnSearchStaff);
            LoadStaff();
        }

        private void LoadStaff(string filterSql = null, params MySqlParameter[] parameters)
        {
            var sql = "SELECT staff_id, first_name, last_name, staff_contact_num FROM staff";
            if (!string.IsNullOrWhiteSpace(filterSql))
            {
                sql += " WHERE " + filterSql;
            }

            staffBindingSource.DataSource = DBHelper.ExecuteQuery(sql, parameters);
            dgvStaff.DataSource = staffBindingSource;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStaffId.Text.Trim(), out var id))
            {
                MessageBox.Show("Enter a valid Staff ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sql = "INSERT INTO staff (staff_id, first_name, last_name, staff_contact_num) VALUES (@id, @first, @last, @contact)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@first", txtFirstName.Text.Trim()),
                new MySqlParameter("@last", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()));

            LoadStaff();
            ClearForm();
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStaffId.Text.Trim(), out var id)) return;

            var sql = "UPDATE staff SET first_name = @first, last_name = @last, staff_contact_num = @contact WHERE staff_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@first", txtFirstName.Text.Trim()),
                new MySqlParameter("@last", txtLastName.Text.Trim()),
                new MySqlParameter("@contact", txtContactNumber.Text.Trim()),
                new MySqlParameter("@id", id));

            LoadStaff();
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStaffId.Text.Trim(), out var id)) return;

            var sql = "DELETE FROM staff WHERE staff_id = @id";
            DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
            LoadStaff();
            ClearForm();
        }

        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            var search = txtSearchStaff.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadStaff();
                return;
            }

            if (int.TryParse(search, out var id))
            {
                LoadStaff("staff_id = @id", new MySqlParameter("@id", id));
                return;
            }

            var queryValue = $"%{search}%";
            LoadStaff("first_name LIKE @q OR last_name LIKE @q OR staff_contact_num LIKE @q", new MySqlParameter("@q", queryValue));
        }

        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0) return;
            var row = (dgvStaff.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
            if (row == null) return;
            txtStaffId.Text = row.Field<int>("staff_id").ToString();
            txtFirstName.Text = row.Field<string>("first_name");
            txtLastName.Text = row.Field<string>("last_name");
            txtContactNumber.Text = row.Field<string>("staff_contact_num");
        }

        private void ClearForm()
        {
            txtStaffId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtSearchStaff.Clear();
        }
    }
}
