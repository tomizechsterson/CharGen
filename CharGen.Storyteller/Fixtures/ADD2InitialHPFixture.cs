using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2InitialHPFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        
        public bool RollHitPoints(string className, int low, int high)
        {
            int hp = _controller.InitialHitPoints(className);
            return hp >= low && hp <= high;
        }
    }
}