using DD35CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class DD35StorageFixture : Fixture
    {
        private readonly DD35CharacterController _controller = new DD35CharacterController();

        public void Get(int id) {}

        public void Create(string name) {}

        public void Update(int id, string name) {}

        public void Delete(int id) {}

        public string CheckName()
        {
            return null;
        }
    }
}