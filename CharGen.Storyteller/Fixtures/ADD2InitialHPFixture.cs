using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2InitialHPFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        
        public void RollHitPoints(string className, int low, int high)
        {
            int hp = _controller.InitialHitPoints(className);
            if (hp < low)
                throw new StorytellerAssertionException($"{hp} HP is below {low}");
            if (hp > high)
                throw new StorytellerAssertionException($"{hp} HP is above {high}");
        }
    }
}