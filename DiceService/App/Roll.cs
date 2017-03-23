using System.Collections.Generic;

namespace DiceService.App
{
    public class Roll
    {
        private readonly int _times;
        private readonly int _sides;

        public Roll(int times, int sides)
        {
            _times = times;
            _sides = sides;
        }

        public List<int> DoRoll()
        {
            var results = new List<int>(_times);

            for (int i = 0; i < _times; i++)
                results.Add(1);

            return results;
        }
    }
}