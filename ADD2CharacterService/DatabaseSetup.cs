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
                    "Race VARCHAR(8) DEFAULT 'none' NULL, " +
                    "CompletionStep INTEGER DEFAULT 1 )";
                connection.Open();
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO ADD2 (Name, PlayedBy, Str, Dex, Con, Int, Wis, Chr, CompletionStep) "
                                      + "SELECT 'Test1', 'Test1', 0, 0, 0, 0, 0, 0, 1 "
                                      + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Test1'); "
                                      + "INSERT INTO ADD2 (Name, PlayedBy, Str, Dex, Con, Int, Wis, Chr, CompletionStep) "
                                      + "SELECT 'Someone', 'Somebody', 0, 0, 0, 0, 0, 0, 2 "
                                      + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Someone'); "
                                      + "INSERT INTO ADD2 (Name, PlayedBy) "
                                      + "SELECT 'Person', 'A Person' "
                                      + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Person');";
                command.ExecuteNonQuery();
            }
        }
    }
}