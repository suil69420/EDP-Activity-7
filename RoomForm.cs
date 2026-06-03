using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyDataGrid(dgvRooms);
            UiTheme.ApplyLabel(lblRoomId);
            UiTheme.ApplyLabel(lblRoomName);
            UiTheme.ApplyLabel(lblBuilding);
            UiTheme.ApplyTextBox(txtRoomId);
            UiTheme.ApplyTextBox(txtRoomName);
            UiTheme.ApplyTextBox(txtBuilding);
            UiTheme.ApplyTextBox(txtSearchRoom);
            UiTheme.ApplyPrimaryButton(btnAddRoom);
            UiTheme.ApplySecondaryButton(btnUpdateRoom);
            UiTheme.ApplySecondaryButton(btnDeleteRoom);
            UiTheme.ApplySecondaryButton(btnSearchRoom);
            LoadRooms();
        }

        private void LoadRooms(string filterSql = null, params MySqlParameter[] parameters)
        {
            var sql = "SELECT room_id, room_name, building FROM room";
            if (!string.IsNullOrWhiteSpace(filterSql))
            {
                sql += " WHERE " + filterSql;
            }

            roomBindingSource.DataSource = DBHelper.ExecuteQuery(sql, parameters);
            dgvRooms.DataSource = roomBindingSource;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRoomId.Text.Trim(), out var id))
            {
                MessageBox.Show("Enter a valid Room ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sql = "INSERT INTO room (room_id, room_name, building) VALUES (@id, @name, @building)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@name", txtRoomName.Text.Trim()),
                new MySqlParameter("@building", txtBuilding.Text.Trim()));

            LoadRooms();
            ClearForm();
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRoomId.Text.Trim(), out var id)) return;

            var sql = "UPDATE room SET room_name = @name, building = @building WHERE room_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@name", txtRoomName.Text.Trim()),
                new MySqlParameter("@building", txtBuilding.Text.Trim()),
                new MySqlParameter("@id", id));

            LoadRooms();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRoomId.Text.Trim(), out var id)) return;

            var sql = "DELETE FROM room WHERE room_id = @id";
            DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
            LoadRooms();
            ClearForm();
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            var search = txtSearchRoom.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadRooms();
                return;
            }

            if (int.TryParse(search, out var id))
            {
                LoadRooms("room_id = @id", new MySqlParameter("@id", id));
                return;
            }

            var queryValue = $"%{search}%";
            LoadRooms("room_name LIKE @q OR building LIKE @q", new MySqlParameter("@q", queryValue));
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0) return;
            var row = (dgvRooms.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
            if (row == null) return;
            txtRoomId.Text = row.Field<int>("room_id").ToString();
            txtRoomName.Text = row.Field<string>("room_name");
            txtBuilding.Text = row.Field<string>("building");
        }

        private void ClearForm()
        {
            txtRoomId.Clear();
            txtRoomName.Clear();
            txtBuilding.Clear();
            txtSearchRoom.Clear();
        }
    }
}
