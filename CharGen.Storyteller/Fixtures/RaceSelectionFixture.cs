using System.Collections.Generic;
using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class RaceSelectionFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private Dictionary<string, int> _statAdjustments = new Dictionary<string, int>();
        
        public string[] RacesAvailableForStats(int str, int dex, int con, int @int, int wis, int chr)
        {
            return _controller.RacesAvailable(str, dex, con, @int, wis, chr);
        }

        public void GetStatAdjustments(string race)
        {
            _statAdjustments = _controller.GetStatAdjustments(race);
        }

        public int AdjustmentCount()
        {
            return _statAdjustments.Count;
        }

        public void Adjustments(string stat1, out int adj1, string stat2, out int adj2)
        {
            try
            {
                adj1 = _statAdjustments[stat1];
                
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException($"The stat {stat1.ToUpper()} was not adjusted for the selected race", e);
            }

            try
            {
                adj2 = _statAdjustments[stat2];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException($"The stat {stat2.ToUpper()} was not adjusted for the selected race", e);
            }
        }
    }
}