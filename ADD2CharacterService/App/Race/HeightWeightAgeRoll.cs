using System.Linq;
using ADD2CharacterService.App.Stats;

namespace ADD2CharacterService.App.Race
{
    internal struct HeightWeightAgeRoll
    {
        public readonly string Race;
        public readonly string Gender;
        private readonly int _baseHeight;
        private readonly int _baseWeight;
        private readonly int _baseAge;
        private readonly DieRoll _heightModifier;
        private readonly DieRoll _weightModifier;
        private readonly DieRoll _ageModifier;

        public HeightWeightAgeRoll(string race, string gender, int baseHeight, int baseWeight, int baseAge, 
            DieRoll heightModifier, DieRoll weightModifier, DieRoll ageModifier)
        {
            Race = race;
            Gender = gender;
            _baseHeight = baseHeight;
            _baseWeight = baseWeight;
            _baseAge = baseAge;
            _heightModifier = heightModifier;
            _weightModifier = weightModifier;
            _ageModifier = ageModifier;
        }

        public int RollHeight()
        {
            return _heightModifier.Roll().Sum() + _baseHeight;
        }

        public int RollWeight()
        {
            return _weightModifier.Roll().Sum() + _baseWeight;
        }

        public int RollAge()
        {
            return _ageModifier.Roll().Sum() + _baseAge;
        }
    }
}