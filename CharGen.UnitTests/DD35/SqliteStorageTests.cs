using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class SqliteStorageTests
    {
        private readonly SqliteConnection _connection;

        public SqliteStorageTests()
        {
            _connection = DD35SqliteInMemoryCharacters.TestConnection();
            new DBSetup(_connection).CreateTables();
        }

        [Fact]
        public void Insert()
        {
            var db = new DD35SqliteInMemoryCharacters(_connection);

            long addedId = db.Add(new CharacterTransferModel { Name = "test" });
            var character = db.Get(addedId);

            Assert.Equal("test", character.Name);
        }

        [Fact]
        public void Update()
        {
            var db = new DD35SqliteInMemoryCharacters(_connection);
            long addedId = db.Add(new CharacterTransferModel { Name = "test" });
            var character = db.Get(addedId);
            Assert.Equal("test", character.Name);

            db.Update(addedId, new CharacterTransferModel { Name = "updated" });

            character = db.Get(addedId);
            Assert.Equal("updated", character.Name);
        }
    }
}