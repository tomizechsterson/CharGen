using DiceService.App;
using Xunit;

namespace DiceService.UnitTests
{
    public class DiceRollingTests
    {
        [Fact]
        public void RollOne_OneSide_SingleOneReturned()
        {
            var rolls = new Roll(1, 1).DoRoll();

            Assert.Equal(1, rolls.Count);
            Assert.True(rolls[0] == 1);
        }

        [Fact]
        public void RollTwo_OneSide_TwoOnesReturned()
        {
            var rolls = new Roll(2, 1).DoRoll();

            Assert.Equal(2, rolls.Count);
        }

        [Fact]
        public void RollThree_SixSides_ThreeOneThruSixReturned()
        {
            var rolls = new Roll(10, 6).DoRoll();

            Assert.Equal(10, rolls.Count);
            Assert.True(rolls.TrueForAll(r => r > 0 && r < 7));
        }
    }
}