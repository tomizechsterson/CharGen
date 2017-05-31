using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Model
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

        public int id()
        {
            return _id;
        }

        public string name()
        {
            using (var conn = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = _connectionString }.ToString()))
            {
                var command = conn.CreateCommand();
                command.CommandText = "SELECT name FROM ADD2 WHERE Id = $id";
                command.Parameters.AddWithValue("$id", _id);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader["name"].ToString();
                }
            }
        }
    }
}