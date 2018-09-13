using System.Collections.Generic;
using System.Linq;

namespace ADD2CharacterService.App.CharacterClass
{
    public class AvailableClasses
    {
        private readonly string _race;
        private readonly int _str;
        private readonly int _dex;
        private readonly int _con;
        private readonly int _int;
        private readonly int _wis;
        private readonly int _chr;
        private readonly List<AvailableClass> _classesAvailable;
        private readonly Dictionary<string, string[]> _multiClassesAvailable;

        public AvailableClasses(string race, int str, int dex, int con, int @int, int wis, int chr)
        {
            _race = race;
            _str = str;
            _dex = dex;
            _con = con;
            _int = @int;
            _wis = wis;
            _chr = chr;
            _classesAvailable = InitializeAvailableClasses();
            _multiClassesAvailable = InitializeAvailableMultiClasses();
        }

        public string[] Select()
        {
            var results = new List<string>();
            results.AddRange(_classesAvailable.Where(c => c.IsAvailable(_race, _str, _dex, _con, _int, _wis, _chr))
                .Select(c => c.Name()));

            foreach(var multiclass in _multiClassesAvailable[_race])
            {
                string[] classes = multiclass.Split('/');
                if (classes.All(c => results.Contains(c)))
                    results.Add(multiclass);
            }

            return results.ToArray();
        }

        private static List<AvailableClass> InitializeAvailableClasses()
        {
            return new List<AvailableClass> {
                new AvailableClass("Fighter", 9, 3, 3, 3, 3, 3, AllRaces()),
                new AvailableClass("Paladin", 12, 3, 9, 3, 13, 17, new[] {"Human"}),
                new AvailableClass("Ranger", 13, 13, 14, 3, 14, 3, new[] {"Elf", "Half-Elf", "Human"}),
                new AvailableClass("Mage", 3, 3, 3, 9, 3, 3, new[] {"Elf", "Half-Elf", "Human"}),
                new AvailableClass("Cleric", 3, 3, 3, 3, 9, 3, AllRaces()),
                new AvailableClass("Druid", 3, 3, 3, 3, 12, 15, new[] {"Half-Elf", "Human"}),
                new AvailableClass("Thief", 3, 9, 3, 3, 3, 3, AllRaces()),
                new AvailableClass("Bard", 3, 12, 3, 13, 3, 15, new[] {"Half-Elf", "Human"})
            };
        }

        private static string[] AllRaces()
        {
            return new[] { "Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human" };
        }

        private static Dictionary<string, string[]> InitializeAvailableMultiClasses()
        {
            var result = new Dictionary<string, string[]>
            {
                { "Dwarf", new[] { "Fighter/Cleric", "Fighter/Thief" } },
                { "Elf", new[] { "Fighter/Mage", "Fighter/Thief", "Mage/Thief", "Fighter/Mage/Thief" } },
                { "Gnome", new[] { "Fighter/Cleric", "Fighter/Thief", "Cleric/Thief" } },
                { "Half-Elf", new[] { "Fighter/Cleric", "Fighter/Thief", "Fighter/Druid", "Fighter/Mage", "Cleric/Ranger", "Cleric/Mage", "Thief/Mage", "Fighter/Mage/Cleric", "Fighter/Mage/Thief" } },
                { "Halfling", new[] { "Fighter/Thief" } },
                { "Human", new string[0] }
            };
            return result;
        }
    }
}