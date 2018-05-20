using System.Linq;

namespace DD35CharacterService.App.HeightWeight
{
    internal struct HeightWeightRoll
    {
        public readonly string Race;
        public readonly string Gender;
        private readonly int _baseHeight;
        private readonly int _baseWeight;
        private readonly DD35DieRoll _heightModifier;
        private readonly DD35DieRoll _weightModifier;

        public HeightWeightRoll(string race, string gender, int baseHeight, int baseWeight, DD35DieRoll heightModifier, DD35DieRoll weightModifier)
        {
            Race = race;
            Gender = gender;
            _baseHeight = baseHeight;
            _baseWeight = baseWeight;
            _heightModifier = heightModifier;
            _weightModifier = weightModifier;
        }

        public int[] Roll()
        {
            int heightRoll = _heightModifier.Roll().Sum();
            return new[] { heightRoll + _baseHeight, _weightModifier.Roll().Sum() * heightRoll + _baseWeight };
        }
    }
}