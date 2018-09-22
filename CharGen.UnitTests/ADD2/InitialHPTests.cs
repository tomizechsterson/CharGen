using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class InitialHPTests
    {
        private const int Repeat = 20;

        [Theory]
        [InlineData(1, 10, "Fighter")]
        [InlineData(1, 10, "Ranger")]
        [InlineData(1, 10, "Paladin")]
        [InlineData(1, 8, "Cleric")]
        [InlineData(1, 8, "Druid")]
        [InlineData(1, 6, "Thief")]
        [InlineData(1, 6, "Bard")]
        [InlineData(1, 4, "Mage")]
        [InlineData(1, 9, "Fighter", "Cleric")]
        [InlineData(1, 8, "Fighter", "Thief")]
        [InlineData(1, 6, "Druid", "Mage")]
        [InlineData(1, 7, "Fighter", "Mage", "Cleric")]
        [InlineData(1, 6, "Fighter", "Mage", "Thief")]
        public void InitialHP(int low, int high, params string[] classNames)
        {
            var random = new System.Random(System.Environment.TickCount);

            for (int i = 0; i < Repeat; i++)
            {
                int hp = new HP(random, classNames).Get();
                Assert.True(hp >= low && hp <= high, $"Repeat# {i.ToString()}");
            }
        }
    }
}