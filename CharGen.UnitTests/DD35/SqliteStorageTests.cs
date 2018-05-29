﻿using DD35CharacterService.ExceptionHandling;
using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class SqliteStorageTests
    {
        private readonly SqliteConnection _testConnection;
        
        public SqliteStorageTests()
        {
            _testConnection = new SqliteConnection("DataSource=:memory:");
            new SqliteDBSetup(_testConnection).CreateTables();
        }

        [Fact]
        public void Insert()
        {
            var db = new DD35SqliteCharacters(_testConnection);

            long addedId = db.Add(new CharacterTransferModel { Name = "test" });

            Assert.Equal("test", db.Get(addedId).Name);
        }

        [Fact]
        public void InsertDuplicate()
        {
            var db = new DD35SqliteCharacters(_testConnection);
            db.Add(new CharacterTransferModel { Name = "duplicate" });

            void Act() => db.Add(new CharacterTransferModel { Name = "duplicate" });

            Assert.Throws<DuplicateAddException>((System.Action)Act);
        }

        [Fact]
        public void Update()
        {
            var db = new DD35SqliteCharacters(_testConnection);
            long addedId = db.Add(new CharacterTransferModel { Name = "test" });
            Assert.Equal("test", db.Get(addedId).Name);

            db.Update(addedId, new CharacterTransferModel { Name = "updated" });

            Assert.Equal("updated", db.Get(addedId).Name);
        }

        [Fact]
        public void Delete()
        {
            var db = new DD35SqliteCharacters(_testConnection);
            long addedId = db.Add(new CharacterTransferModel { Name = "delete" });
            Assert.Equal("delete", db.Get(addedId).Name);

            db.Delete(addedId);

            var character = db.Get(addedId);
            Assert.Equal(0, character.Id);
            Assert.Equal("none", character.Name);
        }
    }
}