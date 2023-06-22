using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace LogBoard.Models
{
    public class DatabaseService
    {
        private string _connectionString;

        public DatabaseService(string databaseHost, int localPort, string databaseUser, string databasePassword, string databaseName)
        {
            _connectionString = $"server={databaseHost};port={localPort};uid={databaseUser};pwd={databasePassword};database={databaseName};";
        }

        public IDbConnection GetDbConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                // 예외가 발생하면 로그를 남깁니다.
                Trace.TraceError($"Error opening database connection: {ex}");
            }
            return connection;
        }
    }
}