using System.Linq;

namespace ADD2CharacterService.CharacterClass
{
    internal struct AvailableClass
    {
        private readonly string _name;
        private readonly int _minStr;
        private readonly int _minDex;
        private readonly int _minCon;
        private readonly int _minInt;
        private readonly int _minWis;
        private readonly int _minChr;
        private readonly string[] _allowableRaces;

        public AvailableClass(string name, int minStr, int minDex, int minCon, int minInt, int minWis, int minChr, string[] allowableRaces)
        {
            _name = name;
            _minStr = minStr;
            _minDex = minDex;
            _minCon = minCon;
            _minInt = minInt;
            _minWis = minWis;
            _minChr = minChr;
            _allowableRaces = allowableRaces;
        }

        public string Name()
        {
            return _name;
        }

        public bool IsAvailable(string race, int str, int dex, int con, int @int, int wis, int chr)
        {
            return _allowableRaces.Contains(race)
                   && str >= _minStr
                   && dex >= _minDex
                   && con >= _minCon
                   && @int >= _minInt
                   && wis >= _minWis
                   && chr >= _minChr;
        }
    }
}