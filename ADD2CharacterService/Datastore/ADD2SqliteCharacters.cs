﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Datastore
{
    public class ADD2SqliteCharacters : ADD2Characters
    {
        private readonly string _connectionString;
        private readonly SqliteConnection _testConnection;

        [ExcludeFromCodeCoverage]
        public ADD2SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ADD2SqliteCharacters(SqliteConnection testConnection)
        {
            _testConnection = testConnection;
        }

        [ExcludeFromCodeCoverage]
        public async Task<IEnumerable<ADD2Character>> Iterate()
        {
            List<ADD2Character> characters;

            if (_testConnection != null)
                characters = await Iterate(_testConnection);
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                    characters = await Iterate(conn);
            }

            return characters;
        }

        [ExcludeFromCodeCoverage]
        public ADD2Character Get(int id)
        {
            return _testConnection != null
                ? new ADD2SqliteCharacter(_testConnection, id)
                : new ADD2SqliteCharacter(_connectionString, id);
        }

        [ExcludeFromCodeCoverage]
        public async Task Add(HttpCharacterModel model)
        {
            if (_testConnection != null)
                await Add(model, _testConnection);
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                    await Add(model, conn);
            }
        }

        [ExcludeFromCodeCoverage]
        public async Task Update(int id, HttpCharacterModel model)
        {
            if (string.IsNullOrEmpty(await Get(id).Name()))
                await Add(model);
            else
            {
                if (_testConnection != null)
                    await Update(id, model, _testConnection);
                else
                {
                    using (var conn = new SqliteConnection(_connectionString))
                        await Update(id, model, conn);
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public async Task Delete(int id)
        {
            if (_testConnection != null)
                await Delete(id, _testConnection);
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                    await Delete(id, conn);
            }
        }

        private static async Task<List<ADD2Character>> Iterate(SqliteConnection connection)
        {
            var characters = new List<ADD2Character>();
            
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ADD2";
            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    characters.Add(connection.ConnectionString.Contains(":memory:")
                        ? new ADD2SqliteCharacter(connection, await reader.GetFieldValueAsync<int>(0))
                        : new ADD2SqliteCharacter(connection.ConnectionString, reader.GetInt32(0)));
                }
            }

            return characters;
        }

        private static async Task Add(HttpCharacterModel model, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO add2 (Name) " +
                "VALUES ($name)";
            command.Parameters.AddWithValue("$name", model.Name);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static async Task Update(int id, HttpCharacterModel model, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE add2 SET Name = $name, " +
                                  "Str = $str, " +
                                  "Dex = $dex, " +
                                  "Con = $con, " +
                                  "Int = $int, " +
                                  "Wis = $wis, " +
                                  "Chr = $chr, " +
                                  "Race = $race, " +
                                  "AvailableRaces = $availableRaces, " +
                                  "Gender = $gender, " +
                                  "Height = $height, " +
                                  "Weight = $weight, " +
                                  "Age = $age, " +
                                  "Class = $className, " +
                                  "AvailableClasses = $availableClasses, " +
                                  "Alignment = $alignment, " +
                                  "AvailableAlignments = $availableAlignments, " +
                                  "HP = $hp, " +
                                  "Paralyze = $paralyze, " +
                                  "Rod = $rod, " +
                                  "Petrification = $petrification, " +
                                  "Breath = $breath, " +
                                  "Spell = $spell, " +
                                  "MoveRate = $moveRate, " +
                                  "Funds = $funds, " +
                                  "CompletionStep = $completionStep " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$name", model.Name);
            command.Parameters.AddWithValue("$str", model.Str);
            command.Parameters.AddWithValue("$dex", model.Dex);
            command.Parameters.AddWithValue("$con", model.Con);
            command.Parameters.AddWithValue("$int", model.Int);
            command.Parameters.AddWithValue("$wis", model.Wis);
            command.Parameters.AddWithValue("$chr", model.Chr);
            command.Parameters.AddWithValue("$race", model.Race ?? "none");
            command.Parameters.AddWithValue("$availableRaces",
                model.AvailableRaces == null ? "none" : string.Join(",", model.AvailableRaces));
            command.Parameters.AddWithValue("$gender", model.Gender ?? "n");
            command.Parameters.AddWithValue("$height", model.Height);
            command.Parameters.AddWithValue("$weight", model.Weight);
            command.Parameters.AddWithValue("$age", model.Age);
            command.Parameters.AddWithValue("$className", model.ClassName ?? "none");
            command.Parameters.AddWithValue("$availableClasses",
                model.AvailableClasses == null ? "none" : string.Join(",", model.AvailableClasses));
            command.Parameters.AddWithValue("$alignment", model.Alignment ?? "none");
            command.Parameters.AddWithValue("$availableAlignments",
                model.AvailableAlignments == null ? "none" : string.Join(",", model.AvailableAlignments));
            command.Parameters.AddWithValue("$hp", model.HP);
            command.Parameters.AddWithValue("$paralyze", model.Paralyze);
            command.Parameters.AddWithValue("$rod", model.Rod);
            command.Parameters.AddWithValue("$petrification", model.Petrification);
            command.Parameters.AddWithValue("$breath", model.Breath);
            command.Parameters.AddWithValue("$spell", model.Spell);
            command.Parameters.AddWithValue("$moveRate", model.MoveRate);
            command.Parameters.AddWithValue("$funds", model.Funds);
            command.Parameters.AddWithValue("$completionStep", model.CompletionStep);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static async Task Delete(int id, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM add2 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}