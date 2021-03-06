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
        public async Task Get()
        {
            var result = _db.Get(1);

            Assert.Equal(1, result.Id());
            Assert.Equal("Test1", await result.Name());
        }

        [Fact]
        public async Task Add()
        {
            await _db.Add(new HttpCharacterModel {Name = "test"});

            var result = _db.Get(4);

            Assert.Equal(4, result.Id());
            Assert.Equal("test", await result.Name());
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
            Assert.Equal("Test1", await character.Name());
            var model = await character.ToModel();
            model.Name = "updated";

            await _db.Update(1, model);
            var updated = _db.Get(1);

            Assert.Equal("updated", await updated.Name());
        }

        [Fact]
        public async Task Update_NullAvailableRaces_PopulatesDbWithNone()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableRaces = null;

            await _db.Update(1, model);
            var updated = _db.Get(1);

            Assert.Equal("none", await updated.AvailableRaces());
        }
        
        [Fact]
        public async Task Update_NullAvailableClasses_PopulatesDbWithNone()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableClasses = null;

            await _db.Update(1, model);
            var updated = _db.Get(1);

            Assert.Equal("none", await updated.AvailableClasses());
        }

        [Fact]
        public async Task Update_NullAvailableAlignments_PopulatesDbWithNone()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableAlignments = null;

            await _db.Update(1, model);
            var updated = _db.Get(1);

            Assert.Equal("none", await updated.AvailableAlignments());
        }

        [Fact]
        public async Task Upsert()
        {
            await _db.Update(4, new HttpCharacterModel {Name = "nonexistent"});

            var inserted = _db.Get(4);

            Assert.Equal("nonexistent", await inserted.Name());
        }

        [Fact]
        public async Task Delete()
        {
            await _db.Delete(1);

            var result = _db.Get(1);

            Assert.Equal("", await result.Name());
            Assert.Equal(0, await result.Str());
        }

        [Fact]
        public async Task ToModel_AvailableRaces()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableRaces = new[] {"Test1", "Test2"};
            await _db.Update(1, model);

            var updatedModel = await _db.Get(1).ToModel();

            Assert.Equal(new[] {"Test1", "Test2"}, updatedModel.AvailableRaces);
        }
        
        [Fact]
        public async Task ToModel_AvailableClasses()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableClasses = new[] {"Test1", "Test2"};
            await _db.Update(1, model);

            var updatedModel = await _db.Get(1).ToModel();

            Assert.Equal(new[] {"Test1", "Test2"}, updatedModel.AvailableClasses);
        }

        [Fact]
        public async Task ToModel_AvailableAlignments()
        {
            var character = _db.Get(1);
            var model = await character.ToModel();
            model.AvailableAlignments = new[] {"Test1", "Test2"};
            await _db.Update(1, model);

            var updatedModel = await _db.Get(1).ToModel();

            Assert.Equal(new[] {"Test1", "Test2"}, updatedModel.AvailableAlignments);
        }
    }
}