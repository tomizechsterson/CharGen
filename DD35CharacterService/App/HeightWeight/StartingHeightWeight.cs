using System.Collections.Generic;
using System.Linq;

namespace DD35CharacterService.App.HeightWeight
{
    public class StartingHeightWeight
    {
        private readonly string _race;
        private readonly string _gender;
        private readonly List<HeightWeightRoll> _heightWeightRolls;

        public StartingHeightWeight(string race, string gender)
        {
            _race = race;
            _gender = gender;
            _heightWeightRolls = InitializeHeightWeightRolls();
        }

        private static List<HeightWeightRoll> InitializeHeightWeightRolls()
        {
            return new List<HeightWeightRoll>
            {
                new HeightWeightRoll("Dwarf", "M", 45, 130, new DD35DieRoll(4, 2), new DD35DieRoll(6, 2)),
                new HeightWeightRoll("Dwarf", "F", 43, 100, new DD35DieRoll(4, 2), new DD35DieRoll(6, 2)),
                new HeightWeightRoll("Elf", "M", 53, 85, new DD35DieRoll(6, 2), new DD35DieRoll(6, 1)),
                new HeightWeightRoll("Elf", "F", 53, 80, new DD35DieRoll(6, 2), new DD35DieRoll(6, 1)),
                new HeightWeightRoll("Gnome", "M", 36, 40, new DD35DieRoll(4, 2), new DD35DieRoll(1, 1)),
                new HeightWeightRoll("Gnome", "F", 34, 35, new DD35DieRoll(4, 2), new DD35DieRoll(1, 1)),
                new HeightWeightRoll("Half-Elf", "M", 55, 100, new DD35DieRoll(8, 2), new DD35DieRoll(4, 2)),
                new HeightWeightRoll("Half-Elf", "F", 53, 80, new DD35DieRoll(8, 2), new DD35DieRoll(4, 2)),
                new HeightWeightRoll("Half-Orc", "M", 58, 150, new DD35DieRoll(12, 2), new DD35DieRoll(6, 2)),
                new HeightWeightRoll("Half-Orc", "F", 53, 110, new DD35DieRoll(12, 2), new DD35DieRoll(6, 2)),
                new HeightWeightRoll("Halfling", "M", 32, 30, new DD35DieRoll(4, 2), new DD35DieRoll(1, 1)),
                new HeightWeightRoll("Halfling", "F", 30, 25, new DD35DieRoll(4, 2), new DD35DieRoll(1, 1)),
                new HeightWeightRoll("Human", "M", 58, 120, new DD35DieRoll(10, 2), new DD35DieRoll(4, 2)),
                new HeightWeightRoll("Human", "F", 53, 85, new DD35DieRoll(10, 2), new DD35DieRoll(4, 2)),
            };
        }

        public int[] Get()
        {
            return _heightWeightRolls.First(h => h.Race == _race && h.Gender == _gender).Roll();
        }
    }
}