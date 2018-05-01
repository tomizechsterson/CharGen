using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2ClassSelectionFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public string[] ClassAbilityMinimums(int str, int dex, int con, int @int, int wis, int chr)
        {
            return new string[1];
        }

        public string[] AvailableClassesForRace(string race)
        {
            return new string[1];
        }
    }
}