using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests
{
    public class BaseMovementTests
    {
        [Theory]
        [InlineData("Dwarf", 6)]
        [InlineData("Elf", 12)]
        [InlineData("Gnome", 6)]
        [InlineData("Half-Elf", 12)]
        [InlineData("Halfling", 6)]
        [InlineData("Human", 12)]
        public void BaseMovementRateForRace(string race, int expectedMovementRate)
        {
            int rate = new MovementRate(race).Get();

            Assert.Equal(expectedMovementRate, rate);
        }
    }
}