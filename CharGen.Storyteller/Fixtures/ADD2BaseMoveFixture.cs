using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2BaseMoveFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public int GetBaseMovement([SelectionValues("Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")] string race)
        {
            return _controller.BaseMove(race);
        }
    }
}