using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DD35CharacterService.ExceptionHandling;
using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class DD35SqliteCharacters : DD35Characters
    {
        private readonly string _connectionString;
        private readonly SqliteConnection _testConnection;

        [ExcludeFromCodeCoverage]
        public DD35SqliteCharacters(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DD35SqliteCharacters(SqliteConnection testConnection)
        {
            _testConnection = testConnection;
        }

        [ExcludeFromCodeCoverage]
        public CharacterTransferModel[] Get()
        {
            if (_testConnection != null)
                return Get(_testConnection);

            using (var conn = new SqliteConnection(_connectionString))
                return Get(conn);
        }

        [ExcludeFromCodeCoverage]
        public async Task<CharacterTransferModel> Get(long id)
        {
            if (_testConnection != null)
                return await Get(id, _testConnection);
            
            using (var conn = new SqliteConnection(_connectionString))
                return await Get(id, conn);
        }

        [ExcludeFromCodeCoverage]
        public async Task<long> Add(CharacterTransferModel model)
        {
            if (_testConnection != null)
                return await Add(model, _testConnection);
            
            using (var conn = new SqliteConnection(_connectionString))
                return await Add(model, conn);
        }

        [ExcludeFromCodeCoverage]
        public async Task Update(long id, CharacterTransferModel model)
        {
            if (_testConnection != null)
                await Update(id, model, _testConnection);
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                    await Update(id, model, conn);
            }
        }

        [ExcludeFromCodeCoverage]
        public async Task Delete(long id)
        {
            if (_testConnection != null)
                await Delete(id, _testConnection);
            else
            {
                using (var conn = new SqliteConnection(_connectionString))
                    await Delete(id, conn);
            }
        }

        private static CharacterTransferModel[] Get(SqliteConnection connection)
        {
            var results = new List<CharacterTransferModel>();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DD35";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new CharacterTransferModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return results.ToArray();
        }

        private static async Task<CharacterTransferModel> Get(long id, SqliteConnection connection)
        {
            var result = new CharacterTransferModel { Name = "none" };
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dd35 " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id.ToString());
            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Id = await reader.GetFieldValueAsync<int>(0);
                    result.Name = await reader.GetFieldValueAsync<string>(1);
                }
            }

            return result;
        }

        private static async Task<long> Add(CharacterTransferModel model, SqliteConnection connection)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO dd35 (Name) " +
                                      "VALUES ($name)";
                command.Parameters.AddWithValue("$name", model.Name);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                command = connection.CreateCommand();
                command.CommandText = "SELECT last_insert_rowid()";
                await connection.OpenAsync();
                return (long) await command.ExecuteScalarAsync();
            }
            catch (SqliteException e)
            {
                if (e.Message.Contains("UNIQUE constraint failed") && e.Message.Contains("DD35.Name"))
                    throw new DuplicateAddException("That character name is unavailable");

                System.Console.WriteLine(e);
                throw;
            }
        }

        private static async Task Update(long id, CharacterTransferModel model, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE dd35 SET Name = $name " +
                                  "WHERE Id = $id";
            command.Parameters.AddWithValue("$name", model.Name);
            command.Parameters.AddWithValue("$id", id.ToString());
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static async Task Delete(long id, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dd35 WHERE Id = $id";
            command.Parameters.AddWithValue("id", id.ToString());
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}