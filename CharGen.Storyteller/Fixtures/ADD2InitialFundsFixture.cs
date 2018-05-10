using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2InitialFundsFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public bool GetFunds(
            [SelectionValues("Fighter", "Ranger", "Paladin", "Mage", "Thief", "Bard", "Cleric", "Druid")]
            string className, int low, int high)
        {
            int funds = _controller.InitialFunds(className);
            return funds >= low && funds <= high;
        }
    }
}