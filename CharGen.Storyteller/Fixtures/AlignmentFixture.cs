using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class AlignmentFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();

        public string[] AvailableAlignments(string className)
        {
            return _controller.Alignments(className);
        }
    }
}