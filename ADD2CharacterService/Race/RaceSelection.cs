using System.Collections.Generic;
using System.Linq;

namespace ADD2CharacterService.Race
{
    public class RaceSelection
    {
        private readonly int _str;
        private readonly int _dex;
        private readonly int _con;
        private readonly int _int;
        private readonly int _wis;
        private readonly int _chr;
        private readonly List<RaceAvailability> _racesAvailable;

        public RaceSelection(int str, int dex, int con, int @int, int wis, int chr)
        {
            _str = str;
            _dex = dex;
            _con = con;
            _int = @int;
            _wis = wis;
            _chr = chr;
            _racesAvailable = InitializeRaceRequirements();
        }

        private static List<RaceAvailability> InitializeRaceRequirements()
        {
            return new List<RaceAvailability>
            {
                new RaceAvailability("Dwarf", 8, 18, 3, 17, 11, 18, 3, 18, 3, 18, 3, 17),
                new RaceAvailability("Elf", 3, 18, 6, 18, 7, 18, 8, 18, 3, 18, 8, 18),
                new RaceAvailability("Gnome", 6, 18, 3, 18, 8, 18, 6, 18, 3, 18, 3, 18),
                new RaceAvailability("Half-Elf", 3, 18, 6, 18, 6, 18, 4, 18, 3, 18, 3, 18),
                new RaceAvailability("Halfling", 7, 18, 7, 18, 10, 18, 6, 18, 3, 17, 3, 18),
                new RaceAvailability("Human", 3, 18, 3, 18, 3, 18, 3, 18, 3, 18, 3, 18)
            };
        }

        public string[] Select()
        {
            return _racesAvailable.Where(r => r.IsAvailable(_str, _dex, _con, _int, _wis, _chr)).Select(r => r.Name())
                .ToArray();
        }
    }

    internal class RaceAvailability
    {
        private readonly string _name;
        private readonly int _minStr;
        private readonly int _maxStr;
        private readonly int _minDex;
        private readonly int _maxDex;
        private readonly int _minCon;
        private readonly int _maxCon;
        private readonly int _minInt;
        private readonly int _maxInt;
        private readonly int _minWis;
        private readonly int _maxWis;
        private readonly int _minChr;
        private readonly int _maxChr;

        public RaceAvailability(string name, int minStr, int maxStr, int minDex, int maxDex, int minCon, int maxCon,
            int minInt, int maxInt, int minWis, int maxWis, int minChr, int maxChr)
        {
            _name = name;
            _minStr = minStr;
            _maxStr = maxStr;
            _minDex = minDex;
            _maxDex = maxDex;
            _minCon = minCon;
            _maxCon = maxCon;
            _minInt = minInt;
            _maxInt = maxInt;
            _minWis = minWis;
            _maxWis = maxWis;
            _minChr = minChr;
            _maxChr = maxChr;
        }

        public string Name()
        {
            return _name;
        }

        public bool IsAvailable(int str, int dex, int con, int @int, int wis, int chr)
        {
            return str >= _minStr && str <= _maxStr &&
                   dex >= _minDex && dex <= _maxDex &&
                   con >= _minCon && con <= _maxCon &&
                   @int >= _minInt && @int <= _maxInt &&
                   wis >= _minWis && wis <= _maxWis &&
                   chr >= _minChr && chr <= _maxChr;
        }
    }
}