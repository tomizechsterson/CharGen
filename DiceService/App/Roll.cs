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

        public IEnumerable<int> DoRoll()
        {
            throw new System.NotImplementedException();
        }
    }
}