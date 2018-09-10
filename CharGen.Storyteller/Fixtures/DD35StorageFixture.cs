using System.Threading.Tasks;
using DD35CharacterService.Controllers;
using DD35CharacterService.ExceptionHandling;
using DD35CharacterService.Storage;
using Microsoft.Data.Sqlite;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class DD35StorageFixture : Fixture
    {
        private readonly SqliteConnection _testConnection = new SqliteConnection("DataSource=:memory:");
        private DD35CharacterController _controller;
        private CharacterTransferModel _character;

        public override void SetUp()
        {
            new SqliteDBSetup(_testConnection).CreateTables();
            _controller = new DD35CharacterController(new DD35SqliteCharacters(_testConnection));
        }

        public void Get(int id)
        {
            _character = _controller.Get(id);
        }

        public int GetAll()
        {
            return _controller.Get().Length;
        }

        public async Task Create(string name)
        {
            await _controller.Insert(new CharacterTransferModel { Name = name });
        }

        public async Task CreateDup(string name)
        {
            try
            {
                await _controller.Insert(new CharacterTransferModel { Name = name });
            }
            catch (DuplicateAddException) {}
        }

        public async Task Update(int id, string name)
        {
            await _controller.Update(id, new CharacterTransferModel {Name = name});
        }

        public async Task Delete(int id)
        {
            await _controller.Delete(id);
        }

        public string CheckName()
        {
            return _character.Name;
        }
    }
}