using System.Collections.Generic;

namespace DD35CharacterService.App.Stats
{
    public class DD35StatRoll
    {
        private readonly DD35DieRoll _dieRoll;
        private const int _numStatRolls = 6;
        private const int _numRollsPerStat = 4;
        private const int _numSides = 6;

        public DD35StatRoll()
        {
            _dieRoll = new DD35DieRoll(_numSides, _numRollsPerStat);
        }
        
        public List<int[]> RollStats()
        {
            var result = new List<int[]>(_numStatRolls);
            for (int i = 0; i < _numStatRolls; i++)
                result.Add(_dieRoll.Roll());
            return result;
        }
    }
}