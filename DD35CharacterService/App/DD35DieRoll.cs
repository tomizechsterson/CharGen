using System;
using System.Collections.Generic;

namespace DD35CharacterService.App
{
    public class DD35DieRoll
    {
        private readonly int _sides;
        private readonly int _times;
        private readonly Random _random;

        public DD35DieRoll(int sides, int times)
        {
            _sides = sides;
            _times = times;
            _random = new Random(Environment.TickCount);
        }

        public int[] Roll()
        {
            var temp = new List<int>();
            for (int i = 0; i < _times; i++)
                temp.Add(_random.Next(1, _sides + 1));
            return temp.ToArray();
        }
    }
}