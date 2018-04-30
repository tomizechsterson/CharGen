using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Stats;

namespace ADD2CharacterService.Race
{
    public class HeightWeightAge
    {
        private readonly string _race;
        private readonly string _gender;
        private readonly List<HeightWeightAgeRoll> _heightWeightRolls;
        
        public HeightWeightAge(string race, string gender)
        {
            _race = race.ToLower();
            _gender = gender.ToLower();
            _heightWeightRolls = GenerateHeightWeightAgeRolls();
        }

        public int Age()
        {
            return _heightWeightRolls.First(a => a.Race == _race).RollAge();
        }

        public int Height()
        {
            return _heightWeightRolls.First(h => h.Race == _race && h.Gender == _gender).RollHeight();
        }

        public int Weight()
        {
            return _heightWeightRolls.First(h => h.Race == _race && h.Gender == _gender).RollWeight();
        }

        private static List<HeightWeightAgeRoll> GenerateHeightWeightAgeRolls()
        {
            return new List<HeightWeightAgeRoll>
            {
                new HeightWeightAgeRoll("dwarf", "m", 43, 130, 40, new DieRoll(10, 1), new DieRoll(10, 4), new DieRoll(6, 5)),
                new HeightWeightAgeRoll("dwarf", "f", 41, 105, 40, new DieRoll(10, 1), new DieRoll(10, 4), new DieRoll(6, 5)),
                new HeightWeightAgeRoll("elf", "m", 55, 90, 100, new DieRoll(10, 1), new DieRoll(10, 3), new DieRoll(6, 5)),
                new HeightWeightAgeRoll("elf", "f", 50, 70, 100, new DieRoll(10, 1), new DieRoll(10, 3), new DieRoll(6, 5)),
                new HeightWeightAgeRoll("gnome", "m", 38, 72, 60, new DieRoll(6, 1), new DieRoll(4, 5), new DieRoll(12, 3)),
                new HeightWeightAgeRoll("gnome", "f", 36, 68, 60, new DieRoll(6, 1), new DieRoll(5, 4), new DieRoll(12, 3)),
                new HeightWeightAgeRoll("half-elf", "m", 60, 110, 15, new DieRoll(6, 2), new DieRoll(12, 3), new DieRoll(6, 1)),
                new HeightWeightAgeRoll("half-elf", "f", 58, 85, 15, new DieRoll(6, 2), new DieRoll(12, 3), new DieRoll(6, 1)),
                new HeightWeightAgeRoll("halfling", "m", 32, 52, 20, new DieRoll(8, 2), new DieRoll(4, 5), new DieRoll(4, 3)),
                new HeightWeightAgeRoll("halfling", "f", 30, 48, 20, new DieRoll(8, 2), new DieRoll(4, 5), new DieRoll(4, 3)),
                new HeightWeightAgeRoll("human", "m", 60, 140, 15, new DieRoll(10, 2), new DieRoll(10, 6), new DieRoll(4, 1)),
                new HeightWeightAgeRoll("human", "f", 59, 100, 15, new DieRoll(10, 2), new DieRoll(10, 6), new DieRoll(4, 1))
            };
        }
    }
}