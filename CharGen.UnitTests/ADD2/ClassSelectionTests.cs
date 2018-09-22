using ADD2CharacterService.App.CharacterClass;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class ClassSelectionTests
    {
        [Theory]
        [InlineData("Human", 9, 3, 3, 3, 3, 3, "Fighter")]
        [InlineData("Human", 12, 3, 9, 3, 13, 17, "Fighter", "Paladin", "Cleric", "Druid")]
        [InlineData("Human", 13, 13, 14, 3, 14, 3, "Fighter", "Ranger", "Cleric", "Thief")]
        [InlineData("Human", 3, 3, 3, 9, 3, 3, "Mage")]
        [InlineData("Human", 3, 3, 3, 3, 9, 3, "Cleric")]
        [InlineData("Human", 3, 3, 3, 3, 12, 15, "Cleric", "Druid")]
        [InlineData("Human", 3, 9, 3, 3, 3, 3, "Thief")]
        [InlineData("Human", 3, 12, 3, 13, 3, 15, "Mage", "Thief", "Bard")]
        public void ClassAvailabilityFromStats(string race, int str, int dex, int con, int @int, int wis, int chr,
            params string[] expectedClasses)
        {
            AssertClasses(race, str, dex, con, @int, wis, chr, expectedClasses);
        }

        [Theory]
        [InlineData("Dwarf", 13, 13, 14, 13, 14, 17, "Fighter", "Cleric", "Thief", "Fighter/Thief", "Fighter/Cleric")]
        [InlineData("Elf", 13, 13, 14, 13, 14, 17, "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Mage", "Fighter/Thief", "Mage/Thief", "Fighter/Mage/Thief")]
        [InlineData("Gnome", 13, 13, 14, 13, 14, 17, "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief", "Cleric/Thief")]
        [InlineData("Half-Elf", 13, 13, 14, 13, 14, 17, "Fighter", "Ranger", "Mage", "Cleric", "Druid", "Thief", "Bard", "Fighter/Cleric", "Fighter/Thief", "Fighter/Druid", "Fighter/Mage", "Cleric/Ranger", "Druid/Ranger", "Cleric/Mage", "Druid/Mage", "Thief/Mage", "Fighter/Mage/Cleric", "Fighter/Mage/Druid", "Fighter/Mage/Thief")]
        [InlineData("Halfling", 13, 13, 14, 13, 14, 17, "Fighter", "Cleric", "Thief", "Fighter/Thief")]
        [InlineData("Human", 13, 13, 14, 13, 14, 17, "Fighter", "Paladin", "Ranger", "Mage", "Cleric", "Druid", "Thief", "Bard")]
        public void ClassesAvailableByRace(string race, int str, int dex, int con, int @int, int wis, int chr,
            params string[] expectedClasses)
        {
            AssertClasses(race, str, dex, con, @int, wis, chr, expectedClasses);
        }

        private void AssertClasses(string race, int str, int dex, int con, int @int, int wis, int chr, string[] expectedClasses)
        {
            var classes = new AvailableClasses(race, str, dex, con, @int, wis, chr).Select();

            Assert.Equal(expectedClasses.Length, classes.Length);
            foreach (var s in expectedClasses)
                Assert.Contains(s, classes);
        }
    }
}