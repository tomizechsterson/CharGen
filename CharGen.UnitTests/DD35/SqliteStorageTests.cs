using DD35CharacterService.ExceptionHandling;
using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class SqliteStorageTests
    {
        private readonly SqliteConnection _testConnection;
        private readonly DD35SqliteCharacters _db;

        public SqliteStorageTests()
        {
            _testConnection = new SqliteConnection("DataSource=:memory:");
            new SqliteDBSetup(_testConnection).CreateTables();
            _db = new DD35SqliteCharacters(_testConnection);
        }

        [Fact]
        public void GetAll()
        {
            _db.Add(new CharacterTransferModel { Name = "first" });
            _db.Add(new CharacterTransferModel { Name = "second" });

            var results = _db.Get();

            Assert.Equal(2, results.Length);
        }

        [Fact]
        public void Insert()
        {
            long addedId = _db.Add(new CharacterTransferModel { Name = "test" });

            Assert.Equal("test", _db.Get(addedId).Name);
        }

        [Fact]
        public void InsertDuplicate()
        {
            _db.Add(new CharacterTransferModel { Name = "duplicate" });

            void Act() => _db.Add(new CharacterTransferModel { Name = "duplicate" });

            Assert.Throws<DuplicateAddException>((System.Action)Act);
        }

        [Fact]
        public void Update()
        {
            long addedId = _db.Add(new CharacterTransferModel { Name = "test" });
            Assert.Equal("test", _db.Get(addedId).Name);

            _db.Update(addedId, new CharacterTransferModel { Name = "updated" });

            Assert.Equal("updated", _db.Get(addedId).Name);
        }

        [Fact]
        public void Delete()
        {
            long addedId = _db.Add(new CharacterTransferModel { Name = "delete" });
            Assert.Equal("delete", _db.Get(addedId).Name);

            _db.Delete(addedId);

            var character = _db.Get(addedId);
            Assert.Equal(0, character.Id);
            Assert.Equal("none", character.Name);
        }
    }
}