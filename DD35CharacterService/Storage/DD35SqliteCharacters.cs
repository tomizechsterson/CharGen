using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class DD35SqliteCharacters : DD35Characters
    {
        private readonly string _connectionString;
        private readonly SqliteConnection _testConnection;

        public DD35SqliteCharacters(SqliteConnection connection)
        {
            _testConnection = connection;
        }

        public DD35SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqliteConnection TestConnection()
        {
            return new SqliteConnection("DataSource=:memory:");
        }

        public CharacterTransferModel Get(long id)
        {
            var result = new CharacterTransferModel();
            if (_testConnection != null)
            {
                var command = _testConnection.CreateCommand();
                command.CommandText = "SELECT * FROM dd35 " +
                                      "WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id.ToString());
                _testConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                    }
                }
            }
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SELECT * FROM dd35 " +
                                          "WHERE Id = $id";
                    command.Parameters.AddWithValue("$id", id.ToString());
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = reader.GetInt32(0);
                            result.Name = reader.GetString(1);
                        }
                    }
                }
            }

            return result;
        }

        public long Add(CharacterTransferModel model)
        {
            if (_testConnection != null)
            {
                var command = _testConnection.CreateCommand();
                command.CommandText = "INSERT INTO dd35 (Name) " +
                                      "VALUES ($name)";
                command.Parameters.AddWithValue("$name", model.Name);
                _testConnection.Open();
                command.ExecuteNonQuery();

                command = _testConnection.CreateCommand();
                command.CommandText = "SELECT last_insert_rowid()";
                _testConnection.Open();
                return (long)command.ExecuteScalar();
            }

            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO dd35 (Name) " +
                                      "VALUES ($name)";
                command.Parameters.AddWithValue("$name", model.Name);
                conn.Open();
                command.ExecuteNonQuery();

                command = conn.CreateCommand();
                command.CommandText = "SELECT last_insert_rowid()";
                conn.Open();
                return (long)command.ExecuteScalar();
            }
        }
    }
}