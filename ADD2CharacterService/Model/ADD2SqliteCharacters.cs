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

        public IEnumerable<ADD2Character> Iterate()
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

        public ADD2Character Add(string name, string playedby)
        {
            throw new System.NotImplementedException();
        }
    }
}