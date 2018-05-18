using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests
{
    public class SavingThrowTests
    {
        [Theory]
        [InlineData("Cleric", 10, 14, 13, 16, 15)]
        [InlineData("Druid", 10, 14, 13, 16, 15)]
        [InlineData("Thief", 13, 14, 12, 16, 15)]
        [InlineData("Bard", 13, 14, 12, 16, 15)]
        [InlineData("Fighter", 14, 16, 15, 17, 17)]
        [InlineData("Ranger", 14, 16, 15, 17, 17)]
        [InlineData("Paladin", 14, 16, 15, 17, 17)]
        [InlineData("Mage", 14, 11, 13, 15, 12)]
        public void SavingThrows(string className, int paralyze, int rod, int petrification, int breath, int spell)
        {
            var results = new SavingThrows(className).Get();
            
            Assert.Equal(paralyze, results[0]);
            Assert.Equal(rod, results[1]);
            Assert.Equal(petrification, results[2]);
            Assert.Equal(breath, results[3]);
            Assert.Equal(spell, results[4]);
        }
    }
}