using System.Linq;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Model;
using StoryTeller;

namespace ADD2CharacterService.Storyteller.Fixtures
{
    public class ADD2CharacterFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public void Initialize()
        {
            new DatabaseSetup("characters").Setup(); // This name is hardcoded in the controller... Probably a bad thing...
        }

        public int GetAll()
        {
            return _controller.Get().Count();
        }

        public string GetWithId(int id)
        {
            return _controller.Get(id).Name();
        }

        public void AddCharacter(string name)
        {
            _controller.Post(new HttpCharacterModel {Name = name, PlayedBy = "test4"});
        }

        public void UpdateCharacter(int id, string name)
        {
            _controller.Put(id, new HttpCharacterModel {Name = name, PlayedBy = "blah"});
        }

        public void DeleteCharacter(int id)
        {
            _controller.Delete(id);
        }

        public void EmptyDatabase()
        {
            _controller.Delete();
        }
    }
}