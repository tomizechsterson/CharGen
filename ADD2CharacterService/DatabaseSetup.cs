﻿using Microsoft.Data.Sqlite;

namespace ADD2CharacterService
{
    public class DatabaseSetup
    {
        private readonly string _dbName;
        private readonly SqliteConnection _testConnection;

        public DatabaseSetup() : this("default") {}

        public DatabaseSetup(string dbName)
        {
            _dbName = dbName;
        }

        public DatabaseSetup(SqliteConnection connection)
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
                   "PlayedBy VARCHAR(32) DEFAULT 'none' NULL, " +
                   "Str INTEGER DEFAULT 0, " +
                   "Dex INTEGER DEFAULT 0, " +
                   "Con INTEGER DEFAULT 0, " +
                   "Int INTEGER DEFAULT 0, " +
                   "Wis INTEGER DEFAULT 0, " +
                   "Chr INTEGER DEFAULT 0, " +
                   "Race VARCHAR(8) DEFAULT 'none' NULL, " +
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
                   "Unique(Name, PlayedBy) )";
        }

        private static string SeedDataSql()
        {
            return "INSERT INTO ADD2 (Name, PlayedBy, Str, Dex, Con, Int, Wis, Chr, CompletionStep) "
                   + "SELECT 'Test1', 'Test1', 0, 0, 0, 0, 0, 0, 1 "
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Test1'); "
                   + "INSERT INTO ADD2 (Name, PlayedBy, Str, Dex, Con, Int, Wis, Chr, CompletionStep) "
                   + "SELECT 'Someone', 'Somebody', 0, 0, 0, 0, 0, 0, 2 "
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Someone'); "
                   + "INSERT INTO ADD2 (Name, PlayedBy) "
                   + "SELECT 'Person', 'A Person' "
                   + "WHERE NOT EXISTS (SELECT 1 FROM ADD2 WHERE Name = 'Person');";
        }
    }
}