using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests
{
    public class ADD2InitialHPTests
    {
        [Theory]
        [InlineData("Fighter", 1, 10)]
        [InlineData("Ranger", 1, 10)]
        [InlineData("Paladin", 1, 10)]
        [InlineData("Cleric", 1, 8)]
        [InlineData("Druid", 1, 8)]
        [InlineData("Thief", 1, 6)]
        [InlineData("Bard", 1, 6)]
        [InlineData("Mage", 1, 4)]
        public void InitialHP(string className, int low, int high)
        {
            int hp = new HP(className).Get();

            Assert.True(hp >= low);
            Assert.True(hp <= high);
        }
    }
}