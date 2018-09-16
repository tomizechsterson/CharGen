using System.Collections.Generic;
using System.Linq;

namespace ADD2CharacterService.App
{
    public class SavingThrows
    {
        private readonly string _className;
        private readonly Dictionary<string, int[]> _savingThrows;

        public SavingThrows(string className)
        {
            _className = className.Replace("%2F", "/");
            _savingThrows = InitializeSavingThrows();
        }

        public int[] Get()
        {
            if(!_className.Contains("/"))
                return _savingThrows[_className];

            return SavingThrowsForMulticlass();
        }

        private int[] SavingThrowsForMulticlass()
        {
            if (_className.Split("/").Contains("Mage"))
                return _savingThrows["Mage"];
            if (_className.Split("/").Contains("Cleric"))
                return _savingThrows["Cleric"];
            if (_className.Split("/").Contains("Thief"))
                return _savingThrows["Thief"];

            return _savingThrows["Fighter"];
        }

        private static Dictionary<string, int[]> InitializeSavingThrows()
        {
            var results = new Dictionary<string, int[]>
            {
                { "Fighter", new[] { 14, 16, 15, 17, 17 } },
                { "Ranger", new[] { 14, 16, 15, 17, 17 } },
                { "Paladin", new[] { 14, 16, 15, 17, 17 } },
                { "Cleric", new[] { 10, 14, 13, 16, 15 } },
                { "Druid", new[] { 10, 14, 13, 16, 15 } },
                { "Thief", new[] { 13, 14, 12, 16, 15 } },
                { "Bard", new[] { 13, 14, 12, 16, 15 } },
                { "Mage", new[] { 14, 11, 13, 15, 12 } }
            };
            return results;
        }
    }
}