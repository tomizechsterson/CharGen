using System.Collections.Generic;
using DD35CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{    
    public class DD35RaceClassFixture : Fixture
    {
        private readonly DD35CharacterController _controller = new DD35CharacterController();
        private Dictionary<string, int> _statAdjustments = new Dictionary<string, int>();
        
        public string[] ClassesAvailable()
        {
            return _controller.Classes();
        }

        public string[] RacesAvailable()
        {
            return _controller.Races();
        }
        
        public void GetStatAdjustments([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race)
        {
            _statAdjustments = _controller.StatAdjustments(race);
        }

        public int AdjustmentCount()
        {
            return _statAdjustments.Count;
        }
        
        public void Adjustment([SelectionValues("str", "dex", "con", "int", "wis", "chr")] string stat, out int adjustment)
        {
            try
            {
                adjustment = _statAdjustments[stat];
            }
            catch (KeyNotFoundException)
            {
                throw new StorytellerAssertionException($"The stat {stat.ToUpper()} was not adjusted for the selected race");
            }
        }
    }
}