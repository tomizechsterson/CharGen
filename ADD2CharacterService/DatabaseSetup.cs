using Microsoft.Data.Sqlite;

namespace ADD2CharacterService
{
    public class DatabaseSetup
    {
        private readonly string _dbName;

        public DatabaseSetup() : this("default") {}

        public DatabaseSetup(string dbName)
        {
            _dbName = dbName;
        }

        public void Setup()
        {
            using (var connection = new SqliteConnection($"Data Source={_dbName}"))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS ADD2 (Id INTEGER PRIMARY KEY NOT NULL, Name VARCHAR(32) NOT NULL, PlayedBy VARCHAR(32) NOT NULL)";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}