﻿using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public class DD35SqliteInMemoryCharacters : DD35SqliteCharactersDecorator
    {
        private readonly SqliteConnection _testConnection;

        public DD35SqliteInMemoryCharacters(DD35SqliteCharacters characters) : base(characters) {}

        public DD35SqliteInMemoryCharacters(SqliteConnection connection) : base(connection.ConnectionString)
        {
            _testConnection = connection;
        }

        public static SqliteConnection TestConnection()
        {
            return new SqliteConnection("DataSource=:memory:");
        }

        public override CharacterTransferModel Get(long id)
        {
            return GetResult(id, _testConnection);
        }

        public override long Add(CharacterTransferModel model)
        {
            return Add(model, _testConnection);
        }

        public override void Update(long id, CharacterTransferModel model)
        {
            Update(id, model, _testConnection);
        }

        public override void Delete(long id)
        {
            Delete(id, _testConnection);
        }
    }
}