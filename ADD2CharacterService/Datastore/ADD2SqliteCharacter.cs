using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Datastore
{
    public class ADD2SqliteCharacter : ADD2Character
    {
        private readonly string _connectionString;
        private readonly int _id;
        private readonly SqliteConnection _testConnection;

        [ExcludeFromCodeCoverage]
        public ADD2SqliteCharacter(string connectionString, int id)
        {
            _connectionString = connectionString;
            _id = id;
        }

        public ADD2SqliteCharacter(SqliteConnection testConnection, int id)
        {
            _testConnection = testConnection;
            _id = id;
        }

        public int Id()
        {
            return _id;
        }

        public string Name()
        {
            return GetColumnString("Name");
        }

        public int Str()
        {
            return GetColumnInt("Str");
        }

        public int Dex()
        {
            return GetColumnInt("Dex");
        }

        public int Con()
        {
            return GetColumnInt("Con");
        }

        public int Int()
        {
            return GetColumnInt("Int");
        }

        public int Wis()
        {
            return GetColumnInt("Wis");
        }

        public int Chr()
        {
            return GetColumnInt("Chr");
        }

        public string Race()
        {
            return GetColumnString("Race");
        }

        public string Gender()
        {
            return GetColumnString("Gender");
        }

        public int Height()
        {
            return GetColumnInt("Height");
        }

        public int Weight()
        {
            return GetColumnInt("Weight");
        }

        public int Age()
        {
            return GetColumnInt("Age");
        }

        public string ClassName()
        {
            return GetColumnString("Class");
        }

        public string Alignment()
        {
            return GetColumnString("Alignment");
        }

        public int HP()
        {
            return GetColumnInt("HP");
        }

        public int Paralyze()
        {
            return GetColumnInt("Paralyze");
        }

        public int Rod()
        {
            return GetColumnInt("Rod");
        }

        public int Petrification()
        {
            return GetColumnInt("Petrification");
        }

        public int Breath()
        {
            return GetColumnInt("Breath");
        }

        public int Spell()
        {
            return GetColumnInt("Spell");
        }

        public int MoveRate()
        {
            return GetColumnInt("MoveRate");
        }

        public int Funds()
        {
            return GetColumnInt("Funds");
        }

        private int CompletionStep()
        {
            return GetColumnInt("CompletionStep");
        }

        public HttpCharacterModel ToModel()
        {
            return new HttpCharacterModel
            {
                Id = _id,
                Name = Name(),
                Str = Str(),
                Dex = Dex(),
                Con = Con(),
                Int = Int(),
                Wis = Wis(),
                Chr = Chr(),
                Race = Race(),
                Gender = Gender(),
                Height = Height(),
                Weight = Weight(),
                Age = Age(),
                ClassName = ClassName(),
                Alignment = Alignment(),
                HP = HP(),
                Paralyze = Paralyze(),
                Rod = Rod(),
                Petrification = Petrification(),
                Breath = Breath(),
                Spell = Spell(),
                MoveRate = MoveRate(),
                Funds = Funds(),
                CompletionStep = CompletionStep()
            };
        }

        [ExcludeFromCodeCoverage]
        private string GetColumnString(string columnName)
        {
            if (_testConnection != null)
                return GetColumnString(columnName, _testConnection);

            using (var conn = new SqliteConnection(_connectionString))
                return GetColumnString(columnName, conn);
        }

        [ExcludeFromCodeCoverage]
        private int GetColumnInt(string columnName)
        {
            if (_testConnection != null)
                return GetColumnInt(columnName, _testConnection);

            using (var conn = new SqliteConnection(_connectionString))
                return GetColumnInt(columnName, conn);
        }

        private int GetColumnInt(string columnName, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", _id);
            connection.Open();
            using (var reader = command.ExecuteReader())
                return reader.Read() ? reader.GetInt32(0) : 0;
        }

        private string GetColumnString(string columnName, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", _id);
            connection.Open();
            using (var reader = command.ExecuteReader())
                return reader.Read() ? reader.GetString(0) : "";
        }
    }
}