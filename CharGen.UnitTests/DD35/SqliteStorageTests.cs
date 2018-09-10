using System.Threading.Tasks;
using DD35CharacterService.ExceptionHandling;
using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class SqliteStorageTests
    {
        private readonly DD35SqliteCharacters _db;

        public SqliteStorageTests()
        {
            var testConnection = new SqliteConnection("DataSource=:memory:");
            new SqliteDBSetup(testConnection).CreateTables();
            _db = new DD35SqliteCharacters(testConnection);
        }

        [Fact]
        public async Task GetAll()
        {
            await _db.Add(new CharacterTransferModel { Name = "first" });
            await _db.Add(new CharacterTransferModel { Name = "second" });

            var results = _db.Get();

            Assert.Equal(2, results.Length);
        }

        [Fact]
        public async Task Insert()
        {
            long addedId = await _db.Add(new CharacterTransferModel { Name = "test" });

            Assert.Equal("test", (await _db.Get(addedId)).Name);
        }

        [Fact]
        public async Task InsertDuplicate()
        {
            await _db.Add(new CharacterTransferModel { Name = "duplicate" });

            await Assert.ThrowsAsync<DuplicateAddException>(() => _db.Add(new CharacterTransferModel { Name = "duplicate" }));
        }

        [Fact]
        public async Task Update()
        {
            long addedId = await _db.Add(new CharacterTransferModel { Name = "test" });
            Assert.Equal("test", (await _db.Get(addedId)).Name);

            await _db.Update(addedId, new CharacterTransferModel { Name = "updated" });

            Assert.Equal("updated", (await _db.Get(addedId)).Name);
        }

        [Fact]
        public async Task Delete()
        {
            long addedId = await _db.Add(new CharacterTransferModel { Name = "delete" });
            Assert.Equal("delete", (await _db.Get(addedId)).Name);

            await _db.Delete(addedId);

            var character = await _db.Get(addedId);
            Assert.Equal(0, character.Id);
            Assert.Equal("none", character.Name);
        }
    }
}