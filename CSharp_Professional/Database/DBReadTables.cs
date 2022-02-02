using System;
using Npgsql;

namespace Database
{
    public class DBReadTables
    {

        private static string _connectionString;

        public DBReadTables(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GetVersion()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            var sql = "SELECT version()";

            using var cmd = new NpgsqlCommand(sql, connection);
            var version = cmd.ExecuteScalar().ToString();

            Console.WriteLine(version);
        }

        public void GetTables(string[] tablesNames)
        {
            foreach (var table in tablesNames)
            {
                GetTable(table);
            }
        }

        public void GetTable(string tableName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            var sql = "SELECT * from " + tableName;

            using var cmd = new NpgsqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();

            Console.WriteLine("---------Table " + tableName + "------------");

            var row = new object[100];

            while (reader.Read())
            {
                try
                {
                    reader.GetValues(row);

                    foreach (var columnValue in row)
                    {
                        if (columnValue != null)
                            Console.Write(columnValue + "|");
                    }

                    //Console.Write(reader.GetString(1) + "|");
                    Console.Write(Environment.NewLine);
                }
                catch
                {
                }
                finally
                {

                }

            }
            connection.Close();
            Console.WriteLine("---------------------");
        }

    }
}