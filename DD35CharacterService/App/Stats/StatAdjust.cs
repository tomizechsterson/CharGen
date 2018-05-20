using System.Collections.Generic;

namespace DD35CharacterService.App.Stats
{
    public class StatAdjust
    {
        private readonly string _race;
        private readonly Dictionary<string, Dictionary<string, int>> _adjustments;

        public StatAdjust(string race)
        {
            _race = race;
            _adjustments = InitializeAdjustments();
        }

        private Dictionary<string, Dictionary<string, int>> InitializeAdjustments()
        {
            var result = new Dictionary<string, Dictionary<string, int>>();
            result.Add("Dwarf", new Dictionary<string, int> { { "con", 2 }, { "chr", -2 } });
            result.Add("Elf", new Dictionary<string, int> { { "dex", 2 }, { "con", -2 } });
            result.Add("Gnome", new Dictionary<string, int> { { "con", 2 }, { "str", -2 } });
            result.Add("Halfling", new Dictionary<string, int> { { "dex", 2 }, { "str", -2 } });
            result.Add("Half-Elf", new Dictionary<string, int>());
            result.Add("Half-Orc", new Dictionary<string, int> { { "str", 2 }, { "int", -2 }, { "chr", -2 } });
            result.Add("Human", new Dictionary<string, int>());
            return result;
        }

        public Dictionary<string, int> Adjustments()
        {
            return _adjustments[_race];
        }
    }
}