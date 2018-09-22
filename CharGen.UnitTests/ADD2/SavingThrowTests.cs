using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class SavingThrowTests
    {
        [Theory]
        [InlineData(10, 14, 13, 16, 15, "Cleric")]
        [InlineData(10, 14, 13, 16, 15, "Druid")]
        [InlineData(13, 14, 12, 16, 15, "Thief")]
        [InlineData(13, 14, 12, 16, 15, "Bard")]
        [InlineData(14, 16, 15, 17, 17, "Fighter")]
        [InlineData(14, 16, 15, 17, 17, "Ranger")]
        [InlineData(14, 16, 15, 17, 17, "Paladin")]
        [InlineData(14, 11, 13, 15, 12, "Mage")]
        [InlineData(14, 11, 13, 15, 12, "Fighter", "Mage")]
        [InlineData(10, 14, 13, 16, 15, "Fighter", "Cleric")]
        [InlineData(13, 14, 12, 16, 15, "Fighter", "Thief")]
        [InlineData(10, 14, 13, 16, 15, "Fighter", "Druid")]
        [InlineData(14, 11, 13, 15, 12, "Fighter", "Mage", "Thief")]
        public void SavingThrows(int paralyze, int rod, int petrification, int breath, int spell, params string[] classNames)
        {
            var results = new SavingThrows(classNames).Get();

            Assert.Equal(paralyze, results[0]);
            Assert.Equal(rod, results[1]);
            Assert.Equal(petrification, results[2]);
            Assert.Equal(breath, results[3]);
            Assert.Equal(spell, results[4]);
        }
    }
}