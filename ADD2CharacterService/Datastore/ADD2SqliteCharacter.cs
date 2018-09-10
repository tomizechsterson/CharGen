using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.Datastore
{
    public class ADD2SqliteCharacter : ADD2Character
    {
        private readonly string _connectionString;
        private readonly int _id;
        private readonly SqliteConnection _testConnection;

        [ExcludeFromCodeCoverage]
        public ADD2SqliteCharacter(string connectionString, int id)
        {
            _connectionString = connectionString;
            _id = id;
        }

        public ADD2SqliteCharacter(SqliteConnection testConnection, int id)
        {
            _testConnection = testConnection;
            _id = id;
        }

        public int Id()
        {
            return _id;
        }

        public async Task<string> Name()
        {
            return await GetColumnString("Name");
        }

        public async Task<int> Str()
        {
            return await GetColumnInt("Str");
        }

        public async Task<int> Dex()
        {
            return await GetColumnInt("Dex");
        }

        public async Task<int> Con()
        {
            return await GetColumnInt("Con");
        }

        public async Task<int> Int()
        {
            return await GetColumnInt("Int");
        }

        public async Task<int> Wis()
        {
            return await GetColumnInt("Wis");
        }

        public async Task<int> Chr()
        {
            return await GetColumnInt("Chr");
        }

        public async Task<string> Race()
        {
            return await GetColumnString("Race");
        }

        public async Task<string> Gender()
        {
            return await GetColumnString("Gender");
        }

        public async Task<int> Height()
        {
            return await GetColumnInt("Height");
        }

        public async Task<int> Weight()
        {
            return await GetColumnInt("Weight");
        }

        public async Task<int> Age()
        {
            return await GetColumnInt("Age");
        }

        public async Task<string> ClassName()
        {
            return await GetColumnString("Class");
        }

        public async Task<string> Alignment()
        {
            return await GetColumnString("Alignment");
        }

        public async Task<int> HP()
        {
            return await GetColumnInt("HP");
        }

        public async Task<int> Paralyze()
        {
            return await GetColumnInt("Paralyze");
        }

        public async Task<int> Rod()
        {
            return await GetColumnInt("Rod");
        }

        public async Task<int> Petrification()
        {
            return await GetColumnInt("Petrification");
        }

        public async Task<int> Breath()
        {
            return await GetColumnInt("Breath");
        }

        public async Task<int> Spell()
        {
            return await GetColumnInt("Spell");
        }

        public async Task<int> MoveRate()
        {
            return await GetColumnInt("MoveRate");
        }

        public async Task<int> Funds()
        {
            return await GetColumnInt("Funds");
        }

        private async Task<int> CompletionStep()
        {
            return await GetColumnInt("CompletionStep");
        }

        public async Task<HttpCharacterModel> ToModel()
        {
            return new HttpCharacterModel
            {
                Id = _id,
                Name = await Name(),
                Str = await Str(),
                Dex = await Dex(),
                Con = await Con(),
                Int = await Int(),
                Wis = await Wis(),
                Chr = await Chr(),
                Race = await Race(),
                Gender = await Gender(),
                Height = await Height(),
                Weight = await Weight(),
                Age = await Age(),
                ClassName = await ClassName(),
                Alignment = await Alignment(),
                HP = await HP(),
                Paralyze = await Paralyze(),
                Rod = await Rod(),
                Petrification = await Petrification(),
                Breath = await Breath(),
                Spell = await Spell(),
                MoveRate = await MoveRate(),
                Funds = await Funds(),
                CompletionStep = await CompletionStep()
            };
        }

        [ExcludeFromCodeCoverage]
        private async Task<string> GetColumnString(string columnName)
        {
            if (_testConnection != null)
                return await GetColumnString(columnName, _testConnection);

            using (var conn = new SqliteConnection(_connectionString))
                return await GetColumnString(columnName, conn);
        }

        [ExcludeFromCodeCoverage]
        private async Task<int> GetColumnInt(string columnName)
        {
            if (_testConnection != null)
                return await GetColumnInt(columnName, _testConnection);

            using (var conn = new SqliteConnection(_connectionString))
                return await GetColumnInt(columnName, conn);
        }

        private async Task<int> GetColumnInt(string columnName, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", _id);
            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
                return await reader.ReadAsync() ? await reader.GetFieldValueAsync<int>(0) : 0;
        }

        private async Task<string> GetColumnString(string columnName, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT " + columnName + " FROM ADD2 WHERE Id = $id";
            command.Parameters.AddWithValue("$id", _id);
            await connection.OpenAsync();
            using (var reader = command.ExecuteReader())
                return await reader.ReadAsync() ? await reader.GetFieldValueAsync<string>(0) : "";
        }
    }
}