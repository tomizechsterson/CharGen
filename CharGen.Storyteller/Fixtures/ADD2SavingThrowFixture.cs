using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2SavingThrowFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public void GetSavingThrows(string className, out int paralyze, out int rod, out int petrification,
            out int breath, out int spell)
        {
            var savingThrows = _controller.SavingThrows(className);
            paralyze = savingThrows[0];
            rod = savingThrows[1];
            petrification = savingThrows[2];
            breath = savingThrows[3];
            spell = savingThrows[4];
        }
    }
}