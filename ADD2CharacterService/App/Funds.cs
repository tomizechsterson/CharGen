using System;
using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App
{
    public class Funds
    {
        private readonly string _className;
        private readonly Random _random;
        private readonly Dictionary<string, DieRoll> _initialFundRolls;

        public Funds(string className, Random random)
        {
            _className = className.Replace("%2F", "/");
            _random = random;
            _initialFundRolls = InitializeFundRolls();
        }

        public int Get()
        {
            if (_className.Contains("/"))
                return InitialFundsForMulticlass();

            if (_className == "Mage")
                return (_initialFundRolls[_className].Roll().Sum() + 1) * 10;

            return _initialFundRolls[_className].Roll().Sum() * 10;
        }

        private int InitialFundsForMulticlass()
        {
            if (_className.Split("/").Contains("Fighter"))
                return _initialFundRolls["Fighter"].Roll().Sum() * 10;
            if (_className.Split("/").Contains("Cleric"))
                return _initialFundRolls["Cleric"].Roll().Sum() * 10;
            
            return _initialFundRolls["Thief"].Roll().Sum() * 10;
        }

        private Dictionary<string, DieRoll> InitializeFundRolls()
        {
            return new Dictionary<string, DieRoll>
            {
                { "Fighter", new DieRoll(4, 5, _random) }, 
                { "Ranger", new DieRoll(4, 5, _random) },
                { "Paladin", new DieRoll(4, 5, _random) },
                { "Mage", new DieRoll(4, 1, _random) },
                { "Thief", new DieRoll(6, 2, _random) },
                { "Bard", new DieRoll(6, 2, _random) },
                { "Cleric", new DieRoll(6, 3, _random) },
                { "Druid", new DieRoll(6, 3, _random) }
            };
        }
    }
}