using ADD2CharacterService.Race;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace CharGen.UnitTests
{
    public class ADD2RaceSelectionTests
    {
        [Theory]
        [InlineData(8, 7, 11, 8, 3, 8, "Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(8, 7, 10, 8, 3, 8, "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(8, 7, 11, 5, 3, 8, "Dwarf", "Half-Elf", "Human")]
        [InlineData(8, 5, 11, 8, 3, 8, "Dwarf", "Gnome", "Human")]
        [InlineData(8, 5, 11, 3, 3, 8, "Dwarf", "Human")]
        [InlineData(3, 3, 3, 3, 3, 3, "Human" )]
        [InlineData(17, 17, 17, 17, 17, 17, "Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(18, 18, 18, 18, 18, 18, "Elf", "Gnome", "Half-Elf", "Human")]
        [InlineData(18, 18, 18, 18, 17, 18, "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(18, 17, 18, 18, 18, 17, "Dwarf", "Elf", "Gnome", "Half-Elf", "Human")]
        public void RacesAvailable(int str, int dex, int con, int @int, int wis, int chr, params string[] expectedRaces)
        {
            var results = new AvailableRaces(str, dex, con, @int, wis, chr).Select();

            Assert.Equal(expectedRaces.Length, results.Length);
            AssertRaceEntries(results, expectedRaces);
        }

        private static void AssertRaceEntries(string[] results, params string[] expectedRaces)
        {
            foreach (string race in expectedRaces)
                Assert.Contains(race, results);
        }

        [Theory]
        [InlineData("Dwarf", "con", 1, "chr", -1)]
        [InlineData("Elf", "dex", 1, "con", -1)]
        [InlineData("Gnome", "int", 1, "wis", -1)]
        [InlineData("Halfling", "dex", 1, "str", -1)]
        public void RacialStatAdjustments(string selectedRace, string stat1, int adj1, string stat2, int adj2)
        {
            var results = new RacialStatAdjust(selectedRace).Adjustmets();

            Assert.Equal(2, results.Count);
            Assert.True(results.ContainsKey(stat1));
            Assert.Equal(adj1, results[stat1]);
            Assert.True(results.ContainsKey(stat2));
            Assert.Equal(adj2, results[stat2]);
        }

        [Theory]
        [InlineData("Human")]
        [InlineData("Half-Elf")]
        public void RacialStatAdjustments_HumanAndHalfElf(string selectedRace)
        {
            var results = new RacialStatAdjust(selectedRace).Adjustmets();

            Assert.Empty(results);
        }
    }
}