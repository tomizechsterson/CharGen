using ADD2CharacterService.Controllers;
using ADD2CharacterService.Model;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class RaceSelectionFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        
        public string[] RacesAvailableForStats(int str, int dex, int con, int @int, int wis, int chr)
        {
            return _controller.RacesAvailable(str, dex, con, @int, wis, chr);
        }

        public void GetStatAdjustments(string race)
        {
            
        }
    }
}