using Microsoft.Data.Sqlite;

namespace ADD2CharacterService
{
    public class DBSetup
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public DBSetup() : this("default") {}

        public DBSetup(string dbName)
        {
            _dbName = dbName;
        }

        public DBSetup(SqliteConnection connection)
        {
            _testConnection = connection;
        }

        public void Setup()
        {
            if (_testConnection != null)
                ExecuteCommand(_testConnection);
            else
            {
                using (var connection = new SqliteConnection($"Data Source={_dbName}"))
                    ExecuteCommand(connection);
            }
        }

        private static void ExecuteCommand(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "DROP TABLE IF EXISTS ADD2";
            connection.Open();
            cmd.ExecuteNonQuery();
            
            cmd = connection.CreateCommand();
            cmd.CommandText = CreateTableSql();
            connection.Open();
            cmd.ExecuteNonQuery();

            cmd = connection.CreateCommand();
            cmd.CommandText = SeedDataSql();
            cmd.ExecuteNonQuery();
        }

        private static string CreateTableSql()
        {
            return "CREATE TABLE IF NOT EXISTS ADD2 (" +
                   "Id INTEGER PRIMARY KEY NOT NULL, " +
                   "Name VARCHAR(32) NOT NULL, " +
                   "Str INTEGER DEFAULT 0, " +
                   "Dex INTEGER DEFAULT 0, " +
                   "Con INTEGER DEFAULT 0, " +
                   "Int INTEGER DEFAULT 0, " +
                   "Wis INTEGER DEFAULT 0, " +
                   "Chr INTEGER DEFAULT 0, " +
                   "Race VARCHAR(8) DEFAULT 'none' NULL, " +
                   "AvailableRaces VARCHAR(64) DEFAULT 'none' NULL, " +
                   "Gender VARCHAR(1) DEFAULT 'n' NULL, " +
                   "Height INTEGER DEFAULT 0, " +
                   "Weight INTEGER DEFAULT 0, " +
                   "Age INTEGER DEFAULT 0, " +
                   "Class VARCHAR(8) DEFAULT 'none' NULL, " +
                   "Alignment VARCHAR(16) DEFAULT 'none' NULL, " +
                   "HP INTEGER DEFAULT 0, " +
                   "Paralyze INTEGER DEFAULT 0, " +
                   "Rod INTEGER DEFAULT 0, " +
                   "Petrification INTEGER DEFAULT 0, " +
                   "Breath INTEGER DEFAULT 0, " +
                   "Spell INTEGER DEFAULT 0, " +
                   "MoveRate INTEGER DEFAULT 0, " +
                   "Funds INTEGER DEFAULT 0, " +
                   "CompletionStep INTEGER DEFAULT 1, " +
                   "Unique(Name) )";
        }

        private static string SeedDataSql()
        {
            return "INSERT INTO ADD2 (Name, Str, Dex, Con, Int, Wis, Chr, CompletionStep) "
                   + "SELECT 'Test1', 0, 0, 0, 0, 0, 0, 1 "
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Test1'); "
                   + "INSERT INTO ADD2 (Name, Str, Dex, Con, Int, Wis, Chr, Race, Class, Gender, Height, Weight, Age, Alignment, HP, Paralyze, Rod, Petrification, Breath, Spell, MoveRate, Funds, CompletionStep) "
                   + "SELECT 'Someone', 8, 11, 10, 18, 9, 14, 'Human', 'Mage', 'M', 64, 115, 20, 'Neutral Good', 4, 14, 11, 13, 15, 12, 12, 50, 2 "
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Someone'); "
                   + "INSERT INTO ADD2 (Name) "
                   + "SELECT 'Person'"
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Person');";
        }
    }
}
