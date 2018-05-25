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
            {
                var cmd = _testConnection.CreateCommand();
                cmd.CommandText = CreateTableSql();
                _testConnection.Open();
                cmd.ExecuteNonQuery();
            }
            else
            {
                using (var conn = new SqliteConnection($"DataSource={_dbName}"))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = CreateTableSql();
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
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