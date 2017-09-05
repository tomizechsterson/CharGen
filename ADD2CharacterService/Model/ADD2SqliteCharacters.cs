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

            using (var conn = new SqliteConnection(_connectionString))
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

        public ADD2Character Get(int id)
        {
            return new ADD2SqliteCharacter(_connectionString, id);
        }

        public void Add(HttpCharacterModel model)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO add2 (Name, PlayedBy, Str, Dex, Con, Int, Wis, Chr, CompletionStep) " +
                    "VALUES ($name, $playedby, $str, $dex, $con, $int, $wis, $chr, $completionStep)";
                command.Parameters.AddWithValue("$name", model.Name);
                command.Parameters.AddWithValue("$playedby", model.PlayedBy);
                command.Parameters.AddWithValue("$str", model.Str);
                command.Parameters.AddWithValue("$dex", model.Dex);
                command.Parameters.AddWithValue("$con", model.Con);
                command.Parameters.AddWithValue("$int", model.Int);
                command.Parameters.AddWithValue("$wis", model.Wis);
                command.Parameters.AddWithValue("$chr", model.Chr);
                command.Parameters.AddWithValue("$completionStep", model.CompletionStep);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, HttpCharacterModel model)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "UPDATE add2 SET Name = $name, " +
                    "PlayedBy = $playedby, " +
                    "Str = $str, " +
                    "Dex = $dex, " +
                    "Con = $con, " +
                    "Int = $int, " +
                    "Wis = $wis, " +
                    "Chr = $chr, " +
                    "CompletionStep = $completionStep " +
                    "WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);
                command.Parameters.AddWithValue("$name", model.Name);
                command.Parameters.AddWithValue("$playedby", model.PlayedBy);
                command.Parameters.AddWithValue("$str", model.Str);
                command.Parameters.AddWithValue("$dex", model.Dex);
                command.Parameters.AddWithValue("$con", model.Con);
                command.Parameters.AddWithValue("$int", model.Int);
                command.Parameters.AddWithValue("$wis", model.Wis);
                command.Parameters.AddWithValue("$chr", model.Chr);
                command.Parameters.AddWithValue("$completionStep", model.CompletionStep);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "DELETE FROM add2 WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}