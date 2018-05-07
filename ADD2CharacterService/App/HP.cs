using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App
{
    public class HP
    {
        private readonly string _className;
        private readonly Dictionary<string, DieRoll> _initialHpRolls;
        
        public HP(string className)
        {
            _className = className;
            _initialHpRolls = InitializeStartingHPRolls();
        }

        private static Dictionary<string, DieRoll> InitializeStartingHPRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "Fighter", new DieRoll(10, 1) },
                { "Ranger", new DieRoll(10, 1) },
                { "Paladin", new DieRoll(10, 1) },
                { "Cleric", new DieRoll(8, 1) },
                { "Druid", new DieRoll(8, 1) },
                { "Thief", new DieRoll(6, 1) },
                { "Bard", new DieRoll(6, 1) },
                { "Mage", new DieRoll(4, 1) }
            };
        }

        public int GetInitial()
        {
            return _initialHpRolls[_className].Roll().Sum();
        }
    }
}