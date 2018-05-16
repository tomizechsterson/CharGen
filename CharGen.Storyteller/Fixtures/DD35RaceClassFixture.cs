using System.Collections.Generic;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{    
    public class DD35RaceClassFixture : Fixture
    {
        private Dictionary<string, int> _statAdjustments = new Dictionary<string, int>();
        
        public string[] ClassesAvailable()
        {
            return new string[0];
        }

        public string[] RacesAvailable()
        {
            return new string[0];
        }
        
        public void GetStatAdjustments([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race)
        {
            _statAdjustments = new Dictionary<string, int>();
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