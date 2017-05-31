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
                        characters.Add(new ADD2SqliteCharacter(_connectionString, reader.GetInt32(0)));
                    }
                }
            }

            return characters;
        }

        public ADD2Character Add(string name, string playedby)
        {
            ADD2SqliteCharacter character;
            using (var conn = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = _connectionString }.ToString()))
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO ADD2 (Name, PlayedBy) VALUES ($name, $playedby)";
                command.Parameters.AddWithValue("$name", name);
                command.Parameters.AddWithValue("$playedby", playedby);
                conn.Open();
                command.ExecuteNonQuery();

                command = conn.CreateCommand();
                command.CommandText = "select last_insert_rowid()";
                int lastId = (int)command.ExecuteScalar();
                character = new ADD2SqliteCharacter(_connectionString, lastId);
            }

            return character;
        }
    }
}