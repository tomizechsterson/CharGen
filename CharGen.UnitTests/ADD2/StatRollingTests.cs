using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.App.Stats;
using ADD2CharacterService.ExceptionHandling;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace CharGen.UnitTests.ADD2
{
    public class StatRollingTests
    {
        [Theory]
        [InlineData("RollOnce", 6, 3, 2, 19)]
        [InlineData("RollTwice", 12, 3, 2, 19)]
        [InlineData("Assignment", 6, 3, 2, 19)]
        [InlineData("AssignmentDouble", 12, 3, 2, 19)]
        [InlineData("RollFour", 6, 4, 3, 25)]
        [InlineData("AddSevenDice", 7, 1, 0, 7)]
        public void DiceRollingRules(string rule, int numRollsExpected, int numDiceUsedPerRoll,
            int lowBoundForRollTotal, int highBoundForRollTotal)
        {
            var results = new StatRoll(rule).RollStats();

            AssertRolls(results, numRollsExpected, numDiceUsedPerRoll, lowBoundForRollTotal, highBoundForRollTotal);
        }

        [Fact]
        public void InvalidStatRollRule_ThrowsStatRollRuleInvalidException()
        {
            Assert.Throws<StatRollRuleInvalidException>(() => new StatRoll("INVALID").RollStats());
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