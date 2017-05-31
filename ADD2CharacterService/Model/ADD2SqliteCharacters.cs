using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Model
{
    public class ADD2SqliteCharacters : ADD2Characters
    {
        private readonly string _connectionString;

        public ADD2SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ADD2Character> iterate()
        {
            var characters = new List<ADD2Character>();

            using (var conn = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = _connectionString }.ToString()))
            {
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM ADD2";
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                    }
                }
            }

            return characters;
        }

        public ADD2Character add(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}