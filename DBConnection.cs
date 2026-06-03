using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace WindowsFormsApp2
{
    public static class DBConnection
    {
        private const string ConnectionString = "server=127.0.0.1;port=3306;user=root;password=;database=vaccinedb2;";
        private static readonly object lockObject = new object();
        private static MySqlConnection conn;

        public static MySqlConnection GetConnection()
        {
            lock (lockObject)
            {
                if (conn == null)
                {
                    conn = new MySqlConnection(ConnectionString);
                }

                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        conn?.Dispose();
                        conn = null;
                        throw new InvalidOperationException("Failed to open database connection.", ex);
                    }
                }

                return conn;
            }
        }

        public static void CloseConnection()
        {
            lock (lockObject)
            {
                if (conn != null)
                {
                    try
                    {
                        if (conn.State != ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }
                    finally
                    {
                        conn.Dispose();
                        conn = null;
                    }
                }
            }
        }
    }
}
