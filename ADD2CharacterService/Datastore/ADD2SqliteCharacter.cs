using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Datastore
{
    public class ADD2SqliteCharacter : ADD2Character
    {
        private readonly string _connectionString;
        private readonly int _id;

        public ADD2SqliteCharacter(string connectionString, int id)
        {
            _connectionString = connectionString;
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

        public string PlayedBy()
        {
            return GetColumnString("PlayedBy");
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

        public int CompletionStep()
        {
            return GetColumnInt("CompletionStep");
        }

        public HttpCharacterModel ToModel()
        {
            return new HttpCharacterModel
            {
                Id = _id,
                Name = Name(),
                PlayedBy = PlayedBy(),
                Str = Str(),
                Dex = Dex(),
                Con = Con(),
                Int = Int(),
                Wis = Wis(),
                Chr = Chr(),
                CompletionStep = CompletionStep()
            };
        }

        private string GetColumnString(string columnName)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
                command.Parameters.AddWithValue("$id", _id);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? reader.GetString(0) : "";
                }
            }
        }

        private int GetColumnInt(string columnName)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
                command.Parameters.AddWithValue("$id", _id);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? reader.GetInt32(0) : 0;
                }
            }
        }
    }
}