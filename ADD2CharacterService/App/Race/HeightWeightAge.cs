using System;
using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App.Race
{
    public class HeightWeightAge
    {
        private readonly string _race;
        private readonly string _gender;
        private readonly Random _random;
        private readonly List<HeightWeightAgeRoll> _heightWeightRolls;
        
        public HeightWeightAge(string race, string gender, Random random)
        {
            _race = race.ToLower();
            _gender = gender.ToLower();
            _random = random;
            _heightWeightRolls = GenerateHeightWeightAgeRolls();
        }

        public int Height()
        {
            return _heightWeightRolls.First(h => h.Race == _race && h.Gender == _gender).RollHeight();
        }

        public int Weight()
        {
            return _heightWeightRolls.First(h => h.Race == _race && h.Gender == _gender).RollWeight();
        }

        public int Age()
        {
            return _heightWeightRolls.First(a => a.Race == _race).RollAge();
        }

        private List<HeightWeightAgeRoll> GenerateHeightWeightAgeRolls()
        {
            return new List<HeightWeightAgeRoll>
            {
                new("dwarf", "m", 43, 130, 40, new DieRoll(10, 1, _random), new DieRoll(10, 4, _random), new DieRoll(6, 5, _random)),
                new("dwarf", "f", 41, 105, 40, new DieRoll(10, 1, _random), new DieRoll(10, 4, _random), new DieRoll(6, 5, _random)),
                new("elf", "m", 55, 90, 100, new DieRoll(10, 1, _random), new DieRoll(10, 3, _random), new DieRoll(6, 5, _random)),
                new("elf", "f", 50, 70, 100, new DieRoll(10, 1, _random), new DieRoll(10, 3, _random), new DieRoll(6, 5, _random)),
                new("gnome", "m", 38, 72, 60, new DieRoll(6, 1, _random), new DieRoll(4, 5, _random), new DieRoll(12, 3, _random)),
                new("gnome", "f", 36, 68, 60, new DieRoll(6, 1, _random), new DieRoll(4, 5, _random), new DieRoll(12, 3, _random)),
                new("half-elf", "m", 60, 110, 15, new DieRoll(6, 2, _random), new DieRoll(12, 3, _random), new DieRoll(6, 1, _random)),
                new("half-elf", "f", 58, 85, 15, new DieRoll(6, 2, _random), new DieRoll(12, 3, _random), new DieRoll(6, 1, _random)),
                new("halfling", "m", 32, 52, 20, new DieRoll(8, 2, _random), new DieRoll(4, 5, _random), new DieRoll(4, 3, _random)),
                new("halfling", "f", 30, 48, 20, new DieRoll(8, 2, _random), new DieRoll(4, 5, _random), new DieRoll(4, 3, _random)),
                new("human", "m", 60, 140, 15, new DieRoll(10, 2, _random), new DieRoll(10, 6, _random), new DieRoll(4, 1, _random)),
                new("human", "f", 59, 100, 15, new DieRoll(10, 2, _random), new DieRoll(10, 6, _random), new DieRoll(4, 1, _random))
            };
        }
    }
}