using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public class RecordLock
    {
        public int RecordId { get; set; }
        public string TableName { get; set; }
        public string LockedBy { get; set; }
        public DateTime LockedAt { get; set; }
        public int ProcessId { get; set; }
    }

    public static class RecordLockManager
    {
        private static readonly Dictionary<string, RecordLock> locks = new Dictionary<string, RecordLock>();
        private static readonly string currentUser = Environment.UserName;
        private static readonly int currentProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;

        public static bool LockRecord(string tableName, int recordId)
        {
            string key = $"{tableName}_{recordId}";

            lock (locks)
            {
                if (locks.ContainsKey(key))
                {
                    var existingLock = locks[key];
                    if (existingLock.LockedBy != currentUser || existingLock.ProcessId != currentProcessId)
                    {
                        return false;
                    }
                    return true;
                }

                locks[key] = new RecordLock
                {
                    RecordId = recordId,
                    TableName = tableName,
                    LockedBy = currentUser,
                    LockedAt = DateTime.Now,
                    ProcessId = currentProcessId
                };

                return true;
            }
        }

        public static void UnlockRecord(string tableName, int recordId)
        {
            string key = $"{tableName}_{recordId}";

            lock (locks)
            {
                if (locks.ContainsKey(key))
                {
                    locks.Remove(key);
                }
            }
        }

        public static RecordLock GetLock(string tableName, int recordId)
        {
            string key = $"{tableName}_{recordId}";

            lock (locks)
            {
                if (locks.ContainsKey(key))
                {
                    return locks[key];
                }
                return null;
            }
        }

        public static bool IsLocked(string tableName, int recordId)
        {
            return GetLock(tableName, recordId) != null;
        }
    }
}
