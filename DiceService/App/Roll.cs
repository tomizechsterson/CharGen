using System;
using System.Collections.Generic;

namespace DiceService.App
{
    public class Roll
    {
        private readonly int _times;
        private readonly int _sides;
        private readonly Random _random;

        public Roll(int times, int sides)
        {
            _times = times;
            _sides = sides;
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public List<int> DoRoll()
        {
            var results = new List<int>(_times);

            for (int i = 0; i < _times; i++)
                results.Add(_random.Next(1, _sides + 1));

            return results;
        }
    }
}