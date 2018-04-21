using System.Collections.Generic;
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

            AssertRolls(results, 6, 3, 2, 19);
        }

        [Fact]
        public void RollTwiceRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.RollTwice);

            AssertRolls(results, 12, 3, 2, 19);
        }

        [Fact]
        public void AssignmentRule_Returns6Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.Assignment);

            AssertRolls(results, 6, 3, 2, 19);
        }

        [Fact]
        public void AssignmentDoubleRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.AssignmentDouble);

            AssertRolls(results, 12, 3, 2, 19);
        }

        [Fact]
        public void RollFourRule_Returns6RollsOfFourDice()
        {
            var results = _controller.RollStats(StatRollingRule.RollFour);

            AssertRolls(results, 6, 4, 3, 25);
        }

        [Fact]
        public void AddSevenDiceRule_Returns7RollsOfOneDie()
        {
            var results = _controller.RollStats(StatRollingRule.AddSevenDice);

            AssertRolls(results, 7, 1, 0, 7);
        }

        private static void AssertRolls(List<int[]> results, int numRolls, int numDice, int lowerBound, int upperBound)
        {
            Assert.Equal(numRolls, results.Count);
            Assert.True(results.All(x => x.Length == numDice));
            Assert.True(results.All(roll => roll.Sum() > lowerBound && roll.Sum() < upperBound));
        }
    }
}