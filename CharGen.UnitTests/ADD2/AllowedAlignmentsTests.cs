using ADD2CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class AllowedAlignmentsTests
    {
        [Theory]
        [InlineData("Paladin", new [] {"Lawful Good"})]
        [InlineData("Druid", new[] {"True Neutral"})]
        [InlineData("Ranger", new[] {"Lawful Good", "Neutral Good", "Chaotic Good"})]
        [InlineData("Bard", new[] {"Lawful Neutral", "Neutral Good", "True Neutral", "Neutral Evil", "Chaotic Neutral"})]
        [InlineData("Fighter", new[] {"Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral",
            "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil"})]
        [InlineData("Fighter/Mage", new[] {"Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral",
            "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil"})]
        [InlineData("Fighter/Mage/Thief", new[] {"Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral",
            "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil"})]
        public void AllowedAlignmentsForClass(string className, string[] expectedAlignments)
        {
            var alignments = new AllowedAlignments(className).Get();

            Assert.Equal(expectedAlignments.Length, alignments.Length);
            Assert.Equal(expectedAlignments, alignments);
        }
    }
}