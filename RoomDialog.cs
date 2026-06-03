using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class RoomDialog : Form
    {
        public int RoomId { get; set; }
        public bool IsNewRecord { get; set; }

        public RoomDialog()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this, dialog: true);
            UiTheme.ApplySurface(this);
            UiTheme.ApplyLabel(lblRoomName);
            UiTheme.ApplyLabel(lblBuilding);
            UiTheme.ApplyTextBox(txtRoomName);
            UiTheme.ApplyTextBox(txtBuilding);
            UiTheme.ApplyPrimaryButton(btnSave);
            UiTheme.ApplySecondaryButton(btnCancel);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            IsNewRecord = true;
        }

        private void RoomDialog_Load(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                LoadRoomData();
            }
        }

        private void LoadRoomData()
        {
            var sql = "SELECT * FROM room WHERE room_id = @id";
            var dt = DBHelper.ExecuteQuery(sql, new MySqlParameter("@id", RoomId));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtRoomName.Text = row["room_name"].ToString();
                txtBuilding.Text = row["building"].ToString();
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
                    InsertRoom();
                }
                else
                {
                    UpdateRoom();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertRoom()
        {
            var nextId = Convert.ToInt32(DBHelper.ExecuteScalar("SELECT COALESCE(MAX(room_id), 0) + 1 FROM room"));
            var sql = "INSERT INTO room (room_id, room_name, building) VALUES (@id, @name, @building)";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@id", nextId),
                new MySqlParameter("@name", txtRoomName.Text.Trim()),
                new MySqlParameter("@building", txtBuilding.Text.Trim()));
        }

        private void UpdateRoom()
        {
            var sql = "UPDATE room SET room_name = @name, building = @building WHERE room_id = @id";
            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@name", txtRoomName.Text.Trim()),
                new MySqlParameter("@building", txtBuilding.Text.Trim()),
                new MySqlParameter("@id", RoomId));

            RecordLockManager.UnlockRecord("room", RoomId);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Room name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBuilding.Text))
            {
                MessageBox.Show("Building is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsNewRecord)
            {
                RecordLockManager.UnlockRecord("room", RoomId);
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(15, 15);
            this.lblRoomName.Text = "Room Name";

            this.txtRoomName.Location = new System.Drawing.Point(120, 12);
            this.txtRoomName.Size = new System.Drawing.Size(250, 22);

            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(15, 45);
            this.lblBuilding.Text = "Building";

            this.txtBuilding.Location = new System.Drawing.Point(120, 42);
            this.txtBuilding.Size = new System.Drawing.Size(250, 22);

            this.btnSave.Location = new System.Drawing.Point(195, 80);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(285, 80);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 130);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblRoomName);
            this.Name = "RoomDialog";
            this.Text = "Room";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.RoomDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblBuilding;
    }
}
