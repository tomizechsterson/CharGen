using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class InitialFundsTests
    {
        [Theory]
        [InlineData("Fighter", 50, 200)]
        [InlineData("Ranger", 50, 200)]
        [InlineData("Paladin", 50, 200)]
        [InlineData("Mage", 20, 50)]
        [InlineData("Thief", 20, 120)]
        [InlineData("Bard", 20, 120)]
        [InlineData("Cleric", 30, 180)]
        [InlineData("Druid", 30, 180)]
        public void InitialFundsForClass(string className, int lowBound, int highBound)
        {
            int funds = new Funds(className, new System.Random()).Get();

            Assert.True(funds >= lowBound && funds <= highBound);
        }
    }
}