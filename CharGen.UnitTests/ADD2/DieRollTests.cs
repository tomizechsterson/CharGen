using System.Linq;
using ADD2CharacterService.App.Stats;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class DieRollTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(4, 3)]
        [InlineData(6, 3)]
        [InlineData(6, 4)]
        public void RollingDiceAreWithinBounds(int numberOfSides, int numberOfTimesToRoll)
        {
            var dieRoll = new DieRoll(numberOfSides, numberOfTimesToRoll);

            var results = dieRoll.Roll();

            Assert.Equal(numberOfTimesToRoll, results.Length);
            int upperBound = numberOfSides + 1;
            Assert.True(results.ToList().TrueForAll(result => result > 0 && result < upperBound));
        }
    }
}