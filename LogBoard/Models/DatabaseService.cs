using MySql.Data.MySqlClient;
using System.Data;

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
            connection.Open();
            return connection;
        }
    }
}