using System.Collections.Generic;

namespace ADD2CharacterService.Race
{
    public class RacialStatAdjust
    {
        private readonly string _selectedRace;
        private readonly Dictionary<string, Dictionary<string, int>> _racialStatAdjustments;

        public RacialStatAdjust(string selectedRace)
        {
            _selectedRace = selectedRace;
            _racialStatAdjustments = InitializeStatAdjustments();
        }

        public Dictionary<string, int> Adjustmets()
        {
            return _racialStatAdjustments[_selectedRace.ToLower()];
        }

        private Dictionary<string, Dictionary<string, int>> InitializeStatAdjustments()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "dwarf", new Dictionary<string, int> { { "con", 1 }, { "chr", -1 } } },
                { "elf", new Dictionary<string, int> { { "dex", 1 }, { "con", -1 } } },
                { "gnome", new Dictionary<string, int> { { "int", 1 }, { "wis", -1 } } },
                { "half-elf", new Dictionary<string, int>() },
                { "halfling", new Dictionary<string, int> { { "dex", 1 }, { "str", -1 } } },
                { "human", new Dictionary<string, int>() }
            };
        }
    }
}