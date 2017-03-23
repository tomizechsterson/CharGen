using System.Linq;
using DiceService.Model;
using Xunit;

namespace DiceService.UnitTests
{
    public class DiceRollingTests
    {
        [Fact]
        public void RollOne_SixSides_SingleOneThruSixReturned()
        {
            var rolls = new Roll(1, 6).DoRoll();

            Assert.Equal(1, rolls.Count());
        }
    }
}
