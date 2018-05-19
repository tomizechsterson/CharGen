using DD35CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class StatAdjustmentTests
    {
        [Theory]
        [InlineData("Dwarf", "con", 2, "chr", -2)]
        [InlineData("Gnome", "con", 2, "str", -2)]
        [InlineData("Elf", "dex", 2, "con", -2)]
        [InlineData("Halfling", "dex", 2, "str", -2)]
        public void StatAdjustments(string race, string stat1, int adj1, string stat2, int adj2)
        {
            var adjustments = new StatAdjust(race).Adjustments();

            Assert.Equal(2, adjustments.Count);
            Assert.Equal(adjustments[stat1], adj1);
            Assert.Equal(adjustments[stat2], adj2);
        }

        [Theory]
        [InlineData("Human")]
        [InlineData("Half-Elf")]
        public void NonAdjustments(string race)
        {
            var adjustments = new StatAdjust(race).Adjustments();

            Assert.Equal(0, adjustments.Count);
        }

        [Fact]
        public void HalfOrcAdjustments()
        {
            var adjustments = new StatAdjust("Half-Orc").Adjustments();

            Assert.Equal(3, adjustments.Count);
            Assert.Equal(adjustments["str"], 2);
            Assert.Equal(adjustments["int"], -2);
            Assert.Equal(adjustments["chr"], -2);
        }
    }
}