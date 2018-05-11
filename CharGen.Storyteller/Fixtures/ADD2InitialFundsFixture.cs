using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2InitialFundsFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public void GetFunds(
            [SelectionValues("Fighter", "Ranger", "Paladin", "Mage", "Thief", "Bard", "Cleric", "Druid")]
            string className, int low, int high)
        {
            int funds = _controller.InitialFunds(className);
            if (funds < low)
                throw new StorytellerAssertionException($"{funds} is below {low}");
            if (funds > high)
                throw new StorytellerAssertionException($"{funds} is above {high}");
        }
    }
}