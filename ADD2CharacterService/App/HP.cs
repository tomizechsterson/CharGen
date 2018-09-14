using System;
using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App
{
    public class HP
    {
        private readonly string _className;
        private readonly Random _random;
        private readonly Dictionary<string, DieRoll> _initialHpRolls;
        
        public HP(string className, Random random)
        {
            _className = className;
            _random = random;
            _initialHpRolls = InitializeStartingHPRolls();
        }

        private Dictionary<string, DieRoll> InitializeStartingHPRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "Fighter", new DieRoll(10, 1, _random) },
                { "Ranger", new DieRoll(10, 1, _random) },
                { "Paladin", new DieRoll(10, 1, _random) },
                { "Cleric", new DieRoll(8, 1, _random) },
                { "Druid", new DieRoll(8, 1, _random) },
                { "Thief", new DieRoll(6, 1, _random) },
                { "Bard", new DieRoll(6, 1, _random) },
                { "Mage", new DieRoll(4, 1, _random) }
            };
        }

        public int Get()
        {
            return _initialHpRolls[_className].Roll().Sum();
        }
    }
}