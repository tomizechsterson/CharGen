using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App
{
    public class Funds
    {
        private readonly string _className;
        private readonly Dictionary<string, DieRoll> _initialFundRolls;

        public Funds(string className)
        {
            _className = className;
            _initialFundRolls = InitializeFundRolls();
        }

        public int Get()
        {
            if (_className == "Mage")
                return (_initialFundRolls[_className].Roll().Sum() + 1) * 10;

            return _initialFundRolls[_className].Roll().Sum() * 10;
        }

        private static Dictionary<string, DieRoll> InitializeFundRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "Fighter", new DieRoll(4, 5) }, 
                { "Ranger", new DieRoll(4, 5) },
                { "Paladin", new DieRoll(4, 5) },
                { "Mage", new DieRoll(4, 1) },
                { "Thief", new DieRoll(6, 2) },
                { "Bard", new DieRoll(6, 2) },
                { "Cleric", new DieRoll(6, 3) },
                { "Druid", new DieRoll(6, 3) }
            };
        }
    }
}