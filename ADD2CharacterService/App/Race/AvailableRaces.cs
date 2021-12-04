using System.Collections.Generic;
using System.Linq;

namespace ADD2CharacterService.App.Race
{
    public class AvailableRaces
    {
        private readonly int _str;
        private readonly int _dex;
        private readonly int _con;
        private readonly int _int;
        private readonly int _wis;
        private readonly int _chr;
        private readonly List<AvailableRace> _racesAvailable;

        public AvailableRaces(int str, int dex, int con, int @int, int wis, int chr)
        {
            _str = str;
            _dex = dex;
            _con = con;
            _int = @int;
            _wis = wis;
            _chr = chr;
            _racesAvailable = InitializeRaceRequirements();
        }

        private static List<AvailableRace> InitializeRaceRequirements()
        {
            return new List<AvailableRace>
            {
                new AvailableRace("Dwarf", 8, 18, 3, 17, 11, 18, 3, 18, 3, 18, 3, 17),
                new AvailableRace("Elf", 3, 18, 6, 18, 7, 18, 8, 18, 3, 18, 8, 18),
                new AvailableRace("Gnome", 6, 18, 3, 18, 8, 18, 6, 18, 3, 18, 3, 18),
                new AvailableRace("Half-Elf", 3, 18, 6, 18, 6, 18, 4, 18, 3, 18, 3, 18),
                new AvailableRace("Halfling", 7, 18, 7, 18, 10, 18, 6, 18, 3, 17, 3, 18),
                new AvailableRace("Human", 3, 18, 3, 18, 3, 18, 3, 18, 3, 18, 3, 18)
            };
        }

        public string[] Select()
        {
            return _racesAvailable
                .Where(r => r.IsAvailable(_str, _dex, _con, _int, _wis, _chr))
                .Select(r => r.Name())
                .ToArray();
        }
    }
}