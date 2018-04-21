using System;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Model;
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
        }

        [Fact]
        public void RollTwiceRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.RollTwice);

            Assert.Equal(12, results.Count);
        }

        [Fact]
        public void AssignmentRule_Returns6Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.Assignment);

            Assert.Equal(6, results.Count);
        }

        [Fact]
        public void AssignmentDoubleRule_Returns12Rolls()
        {
            var results = _controller.RollStats(StatRollingRule.AssignmentDouble);

            Assert.Equal(12, results.Count);
        }

        [Fact]
        public void RollFourRule_Returns6RollsOfFourDice()
        {
            var results = _controller.RollStats(StatRollingRule.RollFour);

            Assert.Equal(6, results.Count);
        }
        
        [Fact]
        public void AddSevenDiceRule_Returns7RollsOfOneDie()
        {
            var results = _controller.RollStats(StatRollingRule.AddSevenDice);

            Assert.Equal(7, results.Count);
        }
    }
}