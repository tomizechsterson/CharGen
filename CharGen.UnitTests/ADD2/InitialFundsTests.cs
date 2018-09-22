using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class InitialFundsTests
    {
        private const int Repeat = 20;

        [Theory]
        [InlineData(50, 200, "Fighter")]
        [InlineData(50, 200, "Ranger")]
        [InlineData(50, 200, "Paladin")]
        [InlineData(20, 50, "Mage")]
        [InlineData(20, 120, "Thief")]
        [InlineData(20, 120, "Bard")]
        [InlineData(30, 180, "Cleric")]
        [InlineData(30, 180, "Druid")]
        [InlineData(50, 200, "Fighter", "Mage")]
        [InlineData(20, 120, "Mage", "Thief")]
        [InlineData(30, 180, "Mage", "Cleric")]
        [InlineData(50, 200, "Druid", "Ranger")]
        [InlineData(30, 180, "Druid", "Mage")]
        public void InitialFundsForClass(int lowBound, int highBound, params string[] classNames)
        {
            var random = new System.Random(System.Environment.TickCount);

            for (int i = 0; i < Repeat; i++)
            {
                int funds = new Funds(random, classNames).Get();
                Assert.True(funds >= lowBound && funds <= highBound, $"Repeat# {i.ToString()}");
            }
        }
    }
}