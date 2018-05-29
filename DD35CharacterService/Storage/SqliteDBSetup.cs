using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class SqliteDBSetup
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public SqliteDBSetup(string dbName)
        {
            _dbName = dbName;
        }

        public SqliteDBSetup(SqliteConnection connection)
        {
            _testConnection = connection;
        }

        public void CreateTables()
        {
            if (_testConnection != null)
                ExecuteCommand(_testConnection);
            else
            {
                using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                    ExecuteCommand(conn);
            }
        }

        private static void ExecuteCommand(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = CreateTableSql();
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        private static string CreateTableSql()
        {
            return "CREATE TABLE IF NOT EXISTS DD35 (" +
                   "Id INTEGER PRIMARY KEY NOT NULL, " +
                   "Name VARCHAR(32) NOT NULL, " +
                   "Unique(Name))";
        }
    }
}