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
            var character = db.Get(addedId);

            Assert.Equal("test", character.Name);
        }

        [Fact]
        public void Update()
        {
            var db = new DD35SqliteCharacters(_testConnection);
            long addedId = db.Add(new CharacterTransferModel { Name = "test" });
            var character = db.Get(addedId);
            Assert.Equal("test", character.Name);

            db.Update(addedId, new CharacterTransferModel { Name = "updated" });

            character = db.Get(addedId);
            Assert.Equal("updated", character.Name);
        }

        [Fact]
        public void Delete()
        {
            var db = new DD35SqliteCharacters(_testConnection);
            long addedId = db.Add(new CharacterTransferModel { Name = "delete" });
            var character = db.Get(addedId);
            Assert.Equal("delete", character.Name);

            db.Delete(addedId);

            character = db.Get(addedId);
            Assert.Equal(0, character.Id);
            Assert.Equal("none", character.Name);
        }
    }
}