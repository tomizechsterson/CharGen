using System.Collections.Generic;

namespace ADD2CharacterService.App
{
    public class MovementRate
    {
        private readonly string _race;
        private readonly Dictionary<string, int> _movementRates;

        public MovementRate(string race)
        {
            _race = race;
            _movementRates = InitializeMovementRates();
        }

        public int Get()
        {
            return _movementRates[_race];
        }

        private Dictionary<string, int> InitializeMovementRates()
        {
            return new Dictionary<string, int>
            {
                { "Dwarf", 6 }, 
                { "Elf", 12 }, 
                { "Gnome", 6 },
                { "Half-Elf", 12 },
                { "Halfling", 6 },
                { "Human", 12 }
            };
        }
    }
}