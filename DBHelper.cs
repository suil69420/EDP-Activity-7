using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace WindowsFormsApp2
{
    public static class DBHelper
    {
        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            using var cmd = new MySqlCommand(sql, DBConnection.GetConnection());
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (MySqlException ex)
            {
                throw new InvalidOperationException($"Database query failed. SQL: {sql}", ex);
            }

            return table;
        }

        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using var cmd = new MySqlCommand(sql, DBConnection.GetConnection());
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new InvalidOperationException($"Database non-query failed. SQL: {sql}", ex);
            }
        }

        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using var cmd = new MySqlCommand(sql, DBConnection.GetConnection());
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                return cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                throw new InvalidOperationException($"Database scalar query failed. SQL: {sql}", ex);
            }
        }
    }
}
