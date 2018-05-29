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

        public void Create(string name)
        {
            _controller.Insert(new CharacterTransferModel { Name = name });
        }

        public void CreateDup(string name)
        {
            try
            {
                _controller.Insert(new CharacterTransferModel { Name = name });
            }
            catch (DuplicateAddException) {}
        }

        public void Update(int id, string name)
        {
            _controller.Update(id, new CharacterTransferModel {Name = name});
        }

        public void Delete(int id)
        {
            _controller.Delete(id);
        }

        public string CheckName()
        {
            return _character.Name;
        }
    }
}