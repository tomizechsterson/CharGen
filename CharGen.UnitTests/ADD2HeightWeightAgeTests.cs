using ADD2CharacterService.Race;
using Xunit;

namespace CharGen.UnitTests
{
    public class ADD2HeightWeightAgeTests
    {
        [Theory]
        [InlineData("dwarf", 45, 70)]
        [InlineData("Elf", 105, 130)]
        [InlineData("gnome", 63, 96)]
        [InlineData("Half-Elf", 16, 21)]
        [InlineData("halfling", 23, 32)]
        [InlineData("Human", 16, 19)]
        public void AgeBounds(string race, int lowBound, int highBound)
        {
            int age = new HeightWeightAge(race, "m").Age();

            Assert.True(age >= lowBound && age <= highBound);
        }

        [Theory]
        [InlineData("dwarf", "m", 44, 53)]
        [InlineData("dwarf", "F", 42, 51)]
        [InlineData("elf", "M", 56, 65)]
        [InlineData("Elf", "f", 51, 60)]
        [InlineData("gnome", "m", 39, 44)]
        [InlineData("Gnome", "F", 37, 42)]
        [InlineData("half-elf", "M", 62, 72)]
        [InlineData("HALF-ELF", "f", 60, 70)]
        [InlineData("halfling", "m", 34, 48)]
        [InlineData("Halfling", "F", 32, 46)]
        [InlineData("human", "M", 62, 80)]
        [InlineData("HUMAN", "f", 61, 79)]
        public void HeightBounds(string race, string gender, int lowBound, int highBound)
        {
            int height = new HeightWeightAge(race, gender).Height();

            Assert.True(height >= lowBound && height <= highBound);
        }

        [Theory]
        [InlineData("dwarf", "m", 134, 170)]
        [InlineData("dwarf", "f", 109, 145)]
        [InlineData("elf", "M", 93, 120)]
        [InlineData("Elf", "f", 73, 100)]
        [InlineData("Gnome", "m", 77, 92)]
        [InlineData("gnome", "F", 73, 88)]
        [InlineData("half-elf", "M", 113, 146)]
        [InlineData("half-elf", "f", 88, 121)]
        [InlineData("halfling", "m", 57, 72)]
        [InlineData("halfling", "F", 53, 68)]
        [InlineData("human", "M", 146, 200)]
        [InlineData("human", "f", 106, 160)]
        public void WeightBounds(string race, string gender, int lowBound, int highBound)
        {
            int weight = new HeightWeightAge(race, gender).Weight();

            Assert.True(weight >= lowBound && weight <= highBound);
        }
    }
}