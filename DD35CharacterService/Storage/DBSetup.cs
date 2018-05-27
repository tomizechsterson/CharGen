using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class DBSetup
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public DBSetup(string dbName)
        {
            _dbName = dbName;
        }

        public DBSetup(SqliteConnection connection)
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
                {
                    ExecuteCommand(conn);
                }
            }
        }

        private void ExecuteCommand(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = CreateTableSql();
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        private string CreateTableSql()
        {
            return "CREATE TABLE IF NOT EXISTS DD35 (" +
                   "Id INTEGER PRIMARY KEY NOT NULL, " +
                   "Name VARCHAR(32) NOT NULL, " +
                   "Unique(Name))";
        }
    }
}