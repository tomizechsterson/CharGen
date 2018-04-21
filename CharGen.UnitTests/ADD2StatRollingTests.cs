using System.Linq;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Stats;
using Xunit;

namespace CharGen.UnitTests
{
    public class ADD2StatRollingTests
    {
        private readonly ADD2CharacterController _controller;

        public ADD2StatRollingTests()
        {
            _controller = new ADD2CharacterController();
        }
        
        [Fact]
        public void RollOnceRule_Returns6Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.RollOnce);

            Assert.Equal(6, results.Count);
            Assert.True(results.All(x => x.Length == 3));
            Assert.True(results.All(roll => roll.Sum() > 2 && roll.Sum() < 19));
        }

        [Fact]
        public void RollTwiceRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.RollTwice);

            Assert.Equal(12, results.Count);
            Assert.True(results.All(x => x.Length == 3));
            Assert.True(results.All(roll => roll.Sum() > 2 && roll.Sum() < 19));
        }

        [Fact]
        public void AssignmentRule_Returns6Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.Assignment);

            Assert.Equal(6, results.Count);
            Assert.True(results.All(x => x.Length == 3));
            Assert.True(results.All(roll => roll.Sum() > 2 && roll.Sum() < 19));
        }

        [Fact]
        public void AssignmentDoubleRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.AssignmentDouble);

            Assert.Equal(12, results.Count);
            Assert.True(results.All(x => x.Length == 3));
            Assert.True(results.All(roll => roll.Sum() > 2 && roll.Sum() < 19));
        }

        [Fact]
        public void RollFourRule_Returns6RollsOfFourDice()
        {
            var results = _controller.RollStats(StatRollingRule.RollFour);

            Assert.Equal(6, results.Count);
            Assert.True(results.All(x => x.Length == 4));
            Assert.True(results.All(roll => roll.Sum() > 3 && roll.Sum() < 25));
        }
        
        [Fact]
        public void AddSevenDiceRule_Returns7RollsOfOneDie()
        {
            var results = _controller.RollStats(StatRollingRule.AddSevenDice);

            Assert.Equal(7, results.Count);
            Assert.True(results.All(x => x.Length == 1));
            Assert.True(results.All(roll => roll.Sum() > 0 && roll.Sum() < 7));
        }
    }
}