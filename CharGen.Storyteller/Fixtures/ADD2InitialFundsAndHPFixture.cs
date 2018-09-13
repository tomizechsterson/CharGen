using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2InitialFundsAndHPFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private int[] _results;

        public void GivenClass([SelectionValues("Fighter", "Paladin", "Ranger", "Mage", "Cleric", "Druid", "Thief", "Bard")] string className)
        {
            _results = _controller.GetInitialHPGP(className);
        }

        public void CheckHP(int lowBound, int highBound)
        {
            int hp = _results[0];
            if (hp < lowBound)
                throw new StorytellerAssertionException($"{hp} HP is below {lowBound}");
            if (hp > highBound)
                throw new StorytellerAssertionException($"{hp} HP is above {highBound}");
        }

        public void CheckFunds(int lowBound, int highBound)
        {
            int gp = _results[1];
            if (gp < lowBound)
                throw new StorytellerAssertionException($"{gp} GP is below {lowBound}");
            if (gp > highBound)
                throw new StorytellerAssertionException($"{gp} GP is above {highBound}");
        }
    }
}