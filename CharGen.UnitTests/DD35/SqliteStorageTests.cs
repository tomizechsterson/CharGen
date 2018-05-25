﻿using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class SqliteStorageTests
    {
        private readonly SqliteConnection _connection;

        public SqliteStorageTests()
        {
            _connection = DD35SqliteCharacters.TestConnection();
            new DBSetup(_connection).CreateTables();
        }

        [Fact]
        public void Insert()
        {
            var db = new DD35SqliteCharacters(_connection);

            long addedId = db.Add(new CharacterTransferModel { Name = "test" });
            var character = db.Get(addedId);

            Assert.Equal("test", character.Name);
        }
    }
}