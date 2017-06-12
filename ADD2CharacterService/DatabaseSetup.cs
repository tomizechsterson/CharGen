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
                    "CREATE TABLE IF NOT EXISTS ADD2 (" + 
                    "Id INTEGER PRIMARY KEY NOT NULL, " + 
                    "Name VARCHAR(32) NOT NULL, " + 
                    "PlayedBy VARCHAR(32) NOT NULL, " +
                    "Str INTEGER DEFAULT 0, " + 
                    "Dex INTEGER DEFAULT 0, " +
                    "Con INTEGER DEFAULT 0, " +
                    "Int INTEGER DEFAULT 0, " +
                    "Wis INTEGER DEFAULT 0, " +
                    "Chr INTEGER DEFAULT 0," +
                    "IsCompleted BOOLEAN DEFAULT 0 CHECK(IsCompleted IN (0, 1)) )";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}