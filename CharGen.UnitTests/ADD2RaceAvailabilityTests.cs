using ADD2CharacterService.Race;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace CharGen.UnitTests
{
    public class ADD2RaceAvailabilityTests
    {
        [Theory]
        [InlineData(8, 7, 11, 8, 3, 8, "Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(8, 7, 10, 8, 3, 8, "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(8, 7, 11, 5, 3, 8, "Dwarf", "Half-Elf", "Human")]
        [InlineData(8, 5, 11, 8, 3, 8, "Dwarf", "Gnome", "Human")]
        [InlineData(8, 5, 11, 3, 3, 8, "Dwarf", "Human")]
        [InlineData(17, 17, 17, 17, 17, 17, "Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(18, 18, 18, 18, 18, 18, "Elf", "Gnome", "Half-Elf", "Human")]
        [InlineData(18, 18, 18, 18, 17, 18, "Elf", "Gnome", "Half-Elf", "Halfling", "Human")]
        [InlineData(18, 17, 18, 18, 18, 17, "Dwarf", "Elf", "Gnome", "Half-Elf", "Human")]
        public void RacesAvailable(int str, int dex, int con, int @int, int wis, int chr, params string[] expectedRaces)
        {
            var results = new RaceSelection(str, dex, con, @int, wis, chr).Select();

            Assert.Equal(expectedRaces.Length, results.Length);
            AssertRaceEntries(results, expectedRaces);
        }

        private static void AssertRaceEntries(string[] results, params string[] expectedRaces)
        {
            foreach (string race in expectedRaces)
                Assert.Contains(race, results);
        }
    }
}