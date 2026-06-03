using System;
using System.Data;

namespace WindowsFormsApp2
{
    public static class DataModel
    {
        public static DataTable PersonTable { get; }
        public static DataTable StaffTable { get; }
        public static DataTable VaccineTable { get; }
        public static DataTable RoomTable { get; }
        public static DataTable VaccinationTable { get; }
        public static DataTable VaccinationViewTable { get; }

        static DataModel()
        {
            PersonTable = new DataTable("Person");
            PersonTable.Columns.Add("person_id", typeof(int));
            PersonTable.Columns.Add("first_name", typeof(string));
            PersonTable.Columns.Add("last_name", typeof(string));
            PersonTable.Columns.Add("person_contact_num", typeof(string));
            PersonTable.Columns.Add("display_name", typeof(string), "first_name + ' ' + last_name");
            PersonTable.PrimaryKey = new[] { PersonTable.Columns["person_id"] };

            StaffTable = new DataTable("Staff");
            StaffTable.Columns.Add("staff_id", typeof(int));
            StaffTable.Columns.Add("first_name", typeof(string));
            StaffTable.Columns.Add("last_name", typeof(string));
            StaffTable.Columns.Add("staff_contact_num", typeof(string));
            StaffTable.Columns.Add("display_name", typeof(string), "first_name + ' ' + last_name");
            StaffTable.PrimaryKey = new[] { StaffTable.Columns["staff_id"] };

            VaccineTable = new DataTable("Vaccine");
            VaccineTable.Columns.Add("vaccine_id", typeof(int));
            VaccineTable.Columns.Add("vaccine_name", typeof(string));
            VaccineTable.Columns.Add("vaccine_expiry_date", typeof(DateTime));
            VaccineTable.Columns.Add("display_name", typeof(string), "vaccine_name");
            VaccineTable.PrimaryKey = new[] { VaccineTable.Columns["vaccine_id"] };

            RoomTable = new DataTable("Room");
            RoomTable.Columns.Add("room_id", typeof(int));
            RoomTable.Columns.Add("room_name", typeof(string));
            RoomTable.Columns.Add("building", typeof(string));
            RoomTable.Columns.Add("display_name", typeof(string), "room_name");
            RoomTable.PrimaryKey = new[] { RoomTable.Columns["room_id"] };

            VaccinationTable = new DataTable("VaccinationRecord");
            VaccinationTable.Columns.Add("record_id", typeof(int));
            VaccinationTable.Columns.Add("person_id", typeof(int));
            VaccinationTable.Columns.Add("staff_id", typeof(int));
            VaccinationTable.Columns.Add("vaccine_id", typeof(int));
            VaccinationTable.Columns.Add("vaccination_dose", typeof(string));
            VaccinationTable.Columns.Add("vaccination_date", typeof(DateTime));
            VaccinationTable.Columns.Add("room_id", typeof(int));
            VaccinationTable.PrimaryKey = new[] { VaccinationTable.Columns["record_id"] };

            VaccinationViewTable = new DataTable("VaccinationView");
            VaccinationViewTable.Columns.Add("record_id", typeof(int));
            VaccinationViewTable.Columns.Add("person", typeof(string));
            VaccinationViewTable.Columns.Add("staff", typeof(string));
            VaccinationViewTable.Columns.Add("vaccine", typeof(string));
            VaccinationViewTable.Columns.Add("vaccination_dose", typeof(string));
            VaccinationViewTable.Columns.Add("vaccination_date", typeof(DateTime));
            VaccinationViewTable.Columns.Add("room", typeof(string));

            LoadSampleData();
            RefreshVaccinationView();
        }

        private static void LoadSampleData()
        {
            PersonTable.Rows.Add(1, "Juan", "Dela Cruz", "09123456781");
            PersonTable.Rows.Add(2, "Maria", "Santos", "09123456782");
            PersonTable.Rows.Add(3, "Jose", "Rizal", "09123456783");
            PersonTable.Rows.Add(4, "Ana", "Reyes", "09123456784");
            PersonTable.Rows.Add(5, "Pedro", "Gomez", "09123456785");
            PersonTable.Rows.Add(6, "Elena", "Torres", "09123456786");
            PersonTable.Rows.Add(7, "Lito", "Pascual", "09123456787");
            PersonTable.Rows.Add(8, "Rosa", "Villanueva", "09123456788");
            PersonTable.Rows.Add(9, "Ben", "Aquino", "09123456789");
            PersonTable.Rows.Add(10, "Clara", "Garcia", "09123456710");

            StaffTable.Rows.Add(101, "Dr. Mark", "Bautista", "09223456701");
            StaffTable.Rows.Add(102, "Nurse Joy", "Cruz", "09223456702");
            StaffTable.Rows.Add(103, "Dr. Sarah", "Lim", "09223456703");
            StaffTable.Rows.Add(104, "Nurse Lea", "Mendoza", "09223456704");
            StaffTable.Rows.Add(105, "Dr. Sam", "Perez", "09223456705");
            StaffTable.Rows.Add(106, "Nurse Kim", "Go", "09223456706");
            StaffTable.Rows.Add(107, "Dr. Rico", "Blanco", "09223456707");
            StaffTable.Rows.Add(108, "Nurse Pam", "Sy", "09223456708");
            StaffTable.Rows.Add(109, "Dr. Vic", "Sotto", "09223456709");
            StaffTable.Rows.Add(110, "Nurse Eva", "Luna", "09223456710");

            VaccineTable.Rows.Add(501, "Pfizer", new DateTime(2026, 12, 31));
            VaccineTable.Rows.Add(502, "Moderna", new DateTime(2026, 11, 15));
            VaccineTable.Rows.Add(503, "AstraZeneca", new DateTime(2026, 8, 20));
            VaccineTable.Rows.Add(504, "Sinovac", new DateTime(2026, 5, 10));
            VaccineTable.Rows.Add(505, "J&J", new DateTime(2026, 3, 1));
            VaccineTable.Rows.Add(506, "Sputnik V", new DateTime(2026, 9, 12));
            VaccineTable.Rows.Add(507, "Covaxin", new DateTime(2026, 7, 4));
            VaccineTable.Rows.Add(508, "Novavax", new DateTime(2026, 10, 25));
            VaccineTable.Rows.Add(509, "Flu Shot", new DateTime(2026, 2, 14));
            VaccineTable.Rows.Add(510, "Hep-B", new DateTime(2027, 1, 1));

            RoomTable.Rows.Add(1, "Room A", "Main Building");
            RoomTable.Rows.Add(2, "Room B", "Main Building");
            RoomTable.Rows.Add(3, "Room C", "East Wing");
            RoomTable.Rows.Add(4, "Room D", "West Wing");
            RoomTable.Rows.Add(5, "Room E", "North Wing");
            RoomTable.Rows.Add(6, "Clinic 1", "Annex A");
            RoomTable.Rows.Add(7, "Clinic 2", "Annex A");
            RoomTable.Rows.Add(8, "ER 1", "Emergency Block");
            RoomTable.Rows.Add(9, "Lab 1", "Diagnostic Center");
            RoomTable.Rows.Add(10, "Hall A", "Gymnasium");

            VaccinationTable.Rows.Add(1001, 1, 102, 501, "1st Dose", new DateTime(2026, 2, 1), 1);
            VaccinationTable.Rows.Add(1002, 2, 104, 501, "1st Dose", new DateTime(2026, 2, 2), 1);
            VaccinationTable.Rows.Add(1003, 3, 106, 502, "1st Dose", new DateTime(2026, 2, 3), 2);
            VaccinationTable.Rows.Add(1004, 1, 102, 501, "2nd Dose", new DateTime(2026, 2, 22), 1);
            VaccinationTable.Rows.Add(1005, 4, 108, 503, "1st Dose", new DateTime(2026, 2, 5), 3);
            VaccinationTable.Rows.Add(1006, 5, 110, 504, "1st Dose", new DateTime(2026, 2, 6), 4);
            VaccinationTable.Rows.Add(1007, 6, 101, 505, "Single Dose", new DateTime(2026, 2, 7), 5);
            VaccinationTable.Rows.Add(1008, 7, 103, 509, "Annual", new DateTime(2026, 2, 8), 6);
            VaccinationTable.Rows.Add(1009, 8, 105, 510, "1st Dose", new DateTime(2026, 2, 9), 7);
            VaccinationTable.Rows.Add(1010, 9, 107, 502, "1st Dose", new DateTime(2026, 2, 10), 2);
            VaccinationTable.Rows.Add(1011, 5, 102, 501, "2nd Dose", new DateTime(2026, 3, 1), 1);
        }

        public static void RefreshVaccinationView()
        {
            VaccinationViewTable.Rows.Clear();
            foreach (DataRow row in VaccinationTable.Rows)
            {
                var personName = GetPersonName(row["person_id"]);
                var staffName = GetStaffName(row["staff_id"]);
                var vaccineName = GetVaccineName(row["vaccine_id"]);
                var roomName = GetRoomName(row["room_id"]);
                VaccinationViewTable.Rows.Add(
                    row.Field<int>("record_id"),
                    personName,
                    staffName,
                    vaccineName,
                    row.Field<string>("vaccination_dose"),
                    row.Field<DateTime>("vaccination_date"),
                    roomName);
            }
        }

        public static string GetPersonName(object id)
        {
            if (id == null || id == DBNull.Value) return string.Empty;
            var row = PersonTable.Rows.Find(Convert.ToInt32(id));
            return row != null ? row.Field<string>("display_name") : string.Empty;
        }

        public static string GetStaffName(object id)
        {
            if (id == null || id == DBNull.Value) return string.Empty;
            var row = StaffTable.Rows.Find(Convert.ToInt32(id));
            return row != null ? row.Field<string>("display_name") : string.Empty;
        }

        public static string GetVaccineName(object id)
        {
            if (id == null || id == DBNull.Value) return string.Empty;
            var row = VaccineTable.Rows.Find(Convert.ToInt32(id));
            return row != null ? row.Field<string>("vaccine_name") : string.Empty;
        }

        public static string GetRoomName(object id)
        {
            if (id == null || id == DBNull.Value) return string.Empty;
            var row = RoomTable.Rows.Find(Convert.ToInt32(id));
            return row != null ? row.Field<string>("room_name") : string.Empty;
        }
    }
}
