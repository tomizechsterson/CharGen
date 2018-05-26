using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class DD35SqliteCharacters : DD35Characters
    {
        private readonly string _connectionString;

        public DD35SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CharacterTransferModel Get(long id)
        {
            CharacterTransferModel result;
            
            using (var conn = new SqliteConnection(_connectionString))
            {
                result = Get(id, conn);
            }

            return result;
        }

        public long Add(CharacterTransferModel model)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                return Add(model, conn);
            }
        }

        public static CharacterTransferModel Get(long id, SqliteConnection connection)
        {
            var result = new CharacterTransferModel();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dd35 " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id.ToString());
            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Id = reader.GetInt32(0);
                    result.Name = reader.GetString(1);
                }
            }

            return result;
        }

        public static long Add(CharacterTransferModel model, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dd35 (Name) " +
                                  "VALUES ($name)";
            command.Parameters.AddWithValue("$name", model.Name);
            connection.Open();
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "SELECT last_insert_rowid()";
            connection.Open();
            return (long)command.ExecuteScalar();
        }
    }
}