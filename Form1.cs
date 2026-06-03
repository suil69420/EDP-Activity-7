using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private DataGridView dgvPerson, dgvStaff, dgvVaccine, dgvRoom, dgvVaccination;

        public Form1()
        {
            InitializeComponent();
            UiTheme.ApplyForm(this);
            UiTheme.ApplySurface(mainPanel);
            UiTheme.ApplySurface(ribbonPanel);
            UiTheme.ApplySurface(tabControl);
            UiTheme.ApplyLabel(lblDashboardTitle, true);
            UiTheme.ApplySecondaryButton(btnAboutUs);
            UiTheme.ApplyPrimaryButton(btnReportGeneration);
            Icon = new System.Drawing.Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.ico"));
        }

        public void InitializeTabs(TabControl tabControl)
        {
            this.tabControl = tabControl;
            
            btnAboutUs.Click += BtnAboutUs_Click;
            btnReportGeneration.Click += BtnReportGeneration_Click;

            var tabPerson = tabControl.TabPages["tabPerson"];
            var tabStaff = tabControl.TabPages["tabStaff"];
            var tabVaccine = tabControl.TabPages["tabVaccine"];
            var tabRoom = tabControl.TabPages["tabRoom"];
            var tabVaccination = tabControl.TabPages["tabVaccination"];

            SetupPersonTab(tabPerson);
            SetupStaffTab(tabStaff);
            SetupVaccineTab(tabVaccine);
            SetupRoomTab(tabRoom);
            SetupVaccinationTab(tabVaccination);

            // Add event handler for automatic refresh when switching tabs
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Welcome to VaccineCare\n\nA simple desktop system for managing people, staff, vaccines, rooms, and vaccination records.\n\nThis application was developed as a demonstration of C# Windows Forms with MySQL database integration.\n\nThank you for using VaccineCare!",
                "About Us",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnReportGeneration_Click(object sender, EventArgs e)
        {
            using (var reportForm = new ReportGenerationForm())
            {
                reportForm.ShowDialog(this);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                string tabName = tabControl.SelectedTab.Name;

                switch (tabName)
                {
                    case "tabPerson":
                        LoadPersonData();
                        break;
                    case "tabStaff":
                        LoadStaffData();
                        break;
                    case "tabVaccine":
                        LoadVaccineData();
                        break;
                    case "tabRoom":
                        LoadRoomData();
                        break;
                    case "tabVaccination":
                        LoadVaccinationData();
                        break;
                }
            }
        }

        private void SetupPersonTab(TabPage tab)
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(10, 10), Width = 80 };
            var btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(100, 10), Width = 80 };
            var btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(190, 10), Width = 80 };

            btnAdd.Click += (s, e) => AddPersonRecord();
            btnEdit.Click += (s, e) => EditPersonRecord();
            btnDelete.Click += (s, e) => DeletePersonRecord();

            panel.Controls.Add(btnAdd);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            dgvPerson = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };

            tab.Controls.Add(dgvPerson);
            tab.Controls.Add(panel);

            LoadPersonData();
        }

        private void SetupStaffTab(TabPage tab)
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(10, 10), Width = 80 };
            var btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(100, 10), Width = 80 };
            var btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(190, 10), Width = 80 };

            btnAdd.Click += (s, e) => AddStaffRecord();
            btnEdit.Click += (s, e) => EditStaffRecord();
            btnDelete.Click += (s, e) => DeleteStaffRecord();

            panel.Controls.Add(btnAdd);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            dgvStaff = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };

            tab.Controls.Add(dgvStaff);
            tab.Controls.Add(panel);

            LoadStaffData();
        }

        private void SetupVaccineTab(TabPage tab)
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(10, 10), Width = 80 };
            var btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(100, 10), Width = 80 };
            var btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(190, 10), Width = 80 };

            btnAdd.Click += (s, e) => AddVaccineRecord();
            btnEdit.Click += (s, e) => EditVaccineRecord();
            btnDelete.Click += (s, e) => DeleteVaccineRecord();

            panel.Controls.Add(btnAdd);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            dgvVaccine = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };

            tab.Controls.Add(dgvVaccine);
            tab.Controls.Add(panel);

            LoadVaccineData();
        }

        private void SetupRoomTab(TabPage tab)
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(10, 10), Width = 80 };
            var btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(100, 10), Width = 80 };
            var btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(190, 10), Width = 80 };

            btnAdd.Click += (s, e) => AddRoomRecord();
            btnEdit.Click += (s, e) => EditRoomRecord();
            btnDelete.Click += (s, e) => DeleteRoomRecord();

            panel.Controls.Add(btnAdd);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            dgvRoom = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };

            tab.Controls.Add(dgvRoom);
            tab.Controls.Add(panel);

            LoadRoomData();
        }

        private void SetupVaccinationTab(TabPage tab)
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
            var btnAdd = new Button { Text = "Add", Location = new System.Drawing.Point(10, 10), Width = 80 };
            var btnEdit = new Button { Text = "Edit", Location = new System.Drawing.Point(100, 10), Width = 80 };
            var btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(190, 10), Width = 80 };

            btnAdd.Click += (s, e) => AddVaccinationRecord();
            btnEdit.Click += (s, e) => EditVaccinationRecord();
            btnDelete.Click += (s, e) => DeleteVaccinationRecord();

            panel.Controls.Add(btnAdd);
            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            dgvVaccination = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };

            tab.Controls.Add(dgvVaccination);
            tab.Controls.Add(panel);

            LoadVaccinationData();
        }

        private void LoadPersonData()
        {
            // Use a flexible select to avoid runtime errors if the schema differs (e.g. no date_of_birth)
            var sql = "SELECT * FROM person";
            dgvPerson.DataSource = DBHelper.ExecuteQuery(sql);
        }

        private void LoadStaffData()
        {
            var sql = "SELECT * FROM staff";
            dgvStaff.DataSource = DBHelper.ExecuteQuery(sql);
        }

        private void LoadVaccineData()
        {
            var sql = "SELECT * FROM vaccine";
            dgvVaccine.DataSource = DBHelper.ExecuteQuery(sql);
        }

        private void LoadRoomData()
        {
            var sql = "SELECT * FROM room";
            dgvRoom.DataSource = DBHelper.ExecuteQuery(sql);
        }

        private void LoadVaccinationData()
        {
            // Select vaccination records plus basic related info; use LEFT JOIN to tolerate missing related rows
            var sql = @"SELECT vr.*, 
                               p.first_name AS person_first, p.last_name AS person_last, 
                               s.first_name AS staff_first, s.last_name AS staff_last, 
                               v.vaccine_name AS vaccine_name, 
                               r.room_name AS room_name
                        FROM vaccination_record vr
                        LEFT JOIN person p ON vr.person_id = p.person_id
                        LEFT JOIN staff s ON vr.staff_id = s.staff_id
                        LEFT JOIN vaccine v ON vr.vaccine_id = v.vaccine_id
                        LEFT JOIN room r ON vr.room_id = r.room_id";

            dgvVaccination.DataSource = DBHelper.ExecuteQuery(sql);
        }

        private void AddPersonRecord()
        {
            var dialog = new PersonDialog { IsNewRecord = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadPersonData();
            }
        }

        private void EditPersonRecord()
        {
            if (dgvPerson.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int personId = (int)dgvPerson.SelectedRows[0].Cells[0].Value;

            if (!RecordLockManager.LockRecord("person", personId))
            {
                var lockInfo = RecordLockManager.GetLock("person", personId);
                MessageBox.Show($"This record is currently being edited by {lockInfo.LockedBy}. Please try again later.", "Record Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new PersonDialog { PersonId = personId, IsNewRecord = false };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadPersonData();
            }
            else
            {
                RecordLockManager.UnlockRecord("person", personId);
            }
        }

        private void DeletePersonRecord()
        {
            if (dgvPerson.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int personId = (int)dgvPerson.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sql = "DELETE FROM person WHERE person_id = @id";
                DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", personId));
                LoadPersonData();
            }
        }

        private void AddStaffRecord()
        {
            var dialog = new StaffDialog { IsNewRecord = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadStaffData();
            }
        }

        private void EditStaffRecord()
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int staffId = (int)dgvStaff.SelectedRows[0].Cells[0].Value;

            if (!RecordLockManager.LockRecord("staff", staffId))
            {
                var lockInfo = RecordLockManager.GetLock("staff", staffId);
                MessageBox.Show($"This record is currently being edited by {lockInfo.LockedBy}. Please try again later.", "Record Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new StaffDialog { StaffId = staffId, IsNewRecord = false };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadStaffData();
            }
            else
            {
                RecordLockManager.UnlockRecord("staff", staffId);
            }
        }

        private void DeleteStaffRecord()
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int staffId = (int)dgvStaff.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sql = "DELETE FROM staff WHERE staff_id = @id";
                DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", staffId));
                LoadStaffData();
            }
        }

        private void AddVaccineRecord()
        {
            var dialog = new VaccineDialog { IsNewRecord = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadVaccineData();
            }
        }

        private void EditVaccineRecord()
        {
            if (dgvVaccine.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int vaccineId = (int)dgvVaccine.SelectedRows[0].Cells[0].Value;

            if (!RecordLockManager.LockRecord("vaccine", vaccineId))
            {
                var lockInfo = RecordLockManager.GetLock("vaccine", vaccineId);
                MessageBox.Show($"This record is currently being edited by {lockInfo.LockedBy}. Please try again later.", "Record Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new VaccineDialog { VaccineId = vaccineId, IsNewRecord = false };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadVaccineData();
            }
            else
            {
                RecordLockManager.UnlockRecord("vaccine", vaccineId);
            }
        }

        private void DeleteVaccineRecord()
        {
            if (dgvVaccine.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int vaccineId = (int)dgvVaccine.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this vaccine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sql = "DELETE FROM vaccine WHERE vaccine_id = @id";
                DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", vaccineId));
                LoadVaccineData();
            }
        }

        private void AddRoomRecord()
        {
            var dialog = new RoomDialog { IsNewRecord = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData();
            }
        }

        private void EditRoomRecord()
        {
            if (dgvRoom.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int roomId = (int)dgvRoom.SelectedRows[0].Cells[0].Value;

            if (!RecordLockManager.LockRecord("room", roomId))
            {
                var lockInfo = RecordLockManager.GetLock("room", roomId);
                MessageBox.Show($"This record is currently being edited by {lockInfo.LockedBy}. Please try again later.", "Record Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new RoomDialog { RoomId = roomId, IsNewRecord = false };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData();
            }
            else
            {
                RecordLockManager.UnlockRecord("room", roomId);
            }
        }

        private void DeleteRoomRecord()
        {
            if (dgvRoom.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int roomId = (int)dgvRoom.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sql = "DELETE FROM room WHERE room_id = @id";
                DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", roomId));
                LoadRoomData();
            }
        }

        private void AddVaccinationRecord()
        {
            var dialog = new VaccinationDialog { IsNewRecord = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadVaccinationData();
            }
        }

        private void EditVaccinationRecord()
        {
            if (dgvVaccination.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int recordId = (int)dgvVaccination.SelectedRows[0].Cells[0].Value;

            if (!RecordLockManager.LockRecord("vaccination_record", recordId))
            {
                var lockInfo = RecordLockManager.GetLock("vaccination_record", recordId);
                MessageBox.Show($"This record is currently being edited by {lockInfo.LockedBy}. Please try again later.", "Record Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new VaccinationDialog { RecordId = recordId, IsNewRecord = false };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadVaccinationData();
            }
            else
            {
                RecordLockManager.UnlockRecord("vaccination_record", recordId);
            }
        }

        private void DeleteVaccinationRecord()
        {
            if (dgvVaccination.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int recordId = (int)dgvVaccination.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this vaccination record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sql = "DELETE FROM vaccination_record WHERE record_id = @id";
                DBHelper.ExecuteNonQuery(sql, new MySqlParameter("@id", recordId));
                LoadVaccinationData();
            }
        }
    }
}
