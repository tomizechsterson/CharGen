using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Stats;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace CharGen.UnitTests
{
    public class ADD2StatRollingTests
    {
        [Theory]
        [InlineData(StatRollingRule.RollOnce, 6, 3, 2, 19)]
        [InlineData(StatRollingRule.RollTwice, 12, 3, 2, 19)]
        [InlineData(StatRollingRule.Assignment, 6, 3, 2, 19)]
        [InlineData(StatRollingRule.AssignmentDouble, 12, 3, 2, 19)]
        [InlineData(StatRollingRule.RollFour, 6, 4, 3, 25)]
        [InlineData(StatRollingRule.AddSevenDice, 7, 1, 0, 7)]
        public void DiceRollingRules(StatRollingRule rule, int numRollsExpected, int numDiceUsedPerRoll,
            int lowBoundForRollTotal, int highBoundForRollTotal)
        {
            var statRoll = new StatRoll(rule);

            var results = statRoll.RollStats();

            AssertRolls(results, numRollsExpected, numDiceUsedPerRoll, lowBoundForRollTotal, highBoundForRollTotal);
        }

        private static void AssertRolls(List<int[]> results, int numRolls, int numDicePerRoll, int rollLowerBound,
            int rollUpperBound)
        {
            Assert.Equal(numRolls, results.Count);
            Assert.True(results.All(x => x.Length == numDicePerRoll));
            Assert.True(results.All(roll => roll.Sum() > rollLowerBound && roll.Sum() < rollUpperBound));
        }
    }
}