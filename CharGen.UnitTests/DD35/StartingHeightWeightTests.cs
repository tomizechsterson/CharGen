using DD35CharacterService.App.HeightWeight;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class StartingHeightWeightTests
    {
        [Theory]
        [InlineData("Dwarf", "M", 47, 53, 134, 226)]
        [InlineData("Dwarf", "F", 45, 51, 104, 196)]
        [InlineData("Elf", "M", 55, 65, 87, 157)]
        [InlineData("Elf", "F", 55, 65, 82, 152)]
        [InlineData("Gnome", "M", 38, 44, 42, 48)]
        [InlineData("Gnome", "F", 36, 42, 37, 43)]
        [InlineData("Halfling", "M", 34, 40, 32, 38)]
        [InlineData("Halfling", "F", 32, 38, 27, 33)]
        [InlineData("Half-Elf", "M", 57, 71, 104, 228)]
        [InlineData("Half-Elf", "F", 55, 69, 84, 208)]
        [InlineData("Half-Orc", "M", 60, 82, 154, 438)]
        [InlineData("Half-Orc", "F", 55, 77, 114, 398)]
        [InlineData("Human", "M", 60, 78, 124, 280)]
        [InlineData("Human", "F", 55, 73, 89, 245)]
        public void StartingHeightWeight(string race, string gender, int lowHeight, int highHeight, int lowWeight, int highWeight)
        {
            var heightWeight = new StartingHeightWeight(race, gender).Get();

            Assert.True(heightWeight[0] >= lowHeight && heightWeight[0] <= highHeight);
            Assert.True(heightWeight[1] >= lowWeight && heightWeight[1] <= highWeight);
        }
    }
}