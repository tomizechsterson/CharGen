using System.Linq;
using System.Threading.Tasks;
using ADD2CharacterService;
using ADD2CharacterService.Datastore;
using Microsoft.Data.Sqlite;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class SqliteCharactersTests
    {
        private readonly ADD2SqliteCharacters _db;

        public SqliteCharactersTests()
        {
            var testConnection = new SqliteConnection("DataSource=:memory:");
            new DBSetup(testConnection).Setup();
            _db = new ADD2SqliteCharacters(testConnection);
        }

        [Fact]
        public async Task GetAll()
        {
            var results = await _db.Iterate();

            Assert.Equal(3, results.Count());
        }

        [Fact]
        public void Get()
        {
            var result = _db.Get(1);

            Assert.Equal(1, result.Id());
            Assert.Equal("Test1", result.Name());
        }

        [Fact]
        public async Task Add()
        {
            await _db.Add(new HttpCharacterModel {Name = "test"});

            var result = _db.Get(4);

            Assert.Equal(4, result.Id());
            Assert.Equal("test", result.Name());
        }

        [Fact]
        public async Task AddDuplicate()
        {
            await Assert.ThrowsAsync<SqliteException>(() => _db.Add(new HttpCharacterModel { Name = "Test1" }));
        }

        [Fact]
        public async Task Update()
        {
            var character = _db.Get(1);
            Assert.Equal("Test1", character.Name());
            var model = character.ToModel();
            model.Name = "updated";

            await _db.Update(1, model);
            var updated = _db.Get(1);

            Assert.Equal("updated", updated.Name());
        }

        [Fact]
        public void Delete()
        {
            _db.Delete(1);

            var result = _db.Get(1);

            Assert.Equal("", result.Name());
            Assert.Equal(0, result.Str());
        }
    }
}