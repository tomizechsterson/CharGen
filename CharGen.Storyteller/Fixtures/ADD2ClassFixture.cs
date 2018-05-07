using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2ClassFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public string[] ClassAbilityMinimums(int str, int dex, int con, int @int, int wis, int chr)
        {
            return _controller.GetClasses("Human", str, dex, con, @int, wis, chr);
        }

        public string[] AvailableClassesForRace(string race)
        {
            return _controller.GetClasses(race, 13, 13, 14, 13, 14, 17);
        }

        public string[] AvailableClasses(string race, int str, int dex, int con, int @int, int wis, int chr)
        {
            return _controller.GetClasses(race, str, dex, con, @int, wis, chr);
        }
    }
}