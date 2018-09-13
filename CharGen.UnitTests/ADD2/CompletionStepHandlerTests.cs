using ADD2CharacterService.App;
using ADD2CharacterService.Datastore;
using Xunit;

namespace CharGen.UnitTests.ADD2
{
    public class CompletionStepHandlerTests
    {
        [Fact]
        public void CompletionStep2_PopulatesAvailableRaces()
        {
            var model = new HttpCharacterModel {CompletionStep = 2, Str = 9, Dex = 9, Con = 9, Int = 9, Wis = 9, Chr = 9};
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Equal(new[] {"Elf", "Gnome", "Half-Elf", "Human"}, result.AvailableRaces);
        }

        [Fact]
        public void CompletionStep3_PopulatesAvailableClasses()
        {
            var model = new HttpCharacterModel {CompletionStep = 3, Race = "Human", Str = 9, Dex = 9, Con = 9, Int = 9, Wis = 9, Chr = 9};
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Equal(new[] {"Fighter", "Mage", "Cleric", "Thief"}, result.AvailableClasses);
        }

        [Fact]
        public void CompletionStep4_PopulateAvailableAlignments()
        {
            var model = new HttpCharacterModel {CompletionStep = 4, ClassName = "Ranger"};
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Equal(new[] {"Lawful Good", "Neutral Good", "Chaotic Good"}, result.AvailableAlignments);
        }

        [Fact]
        public void CompletionStep1_DoesNotModifyAvailableThings()
        {
            var model = new HttpCharacterModel {CompletionStep = 1};
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Null(result.AvailableRaces);
            Assert.Null(result.AvailableClasses);
            Assert.Null(result.AvailableAlignments);
        }

        [Fact]
        public void CompletionStepAbove4_DoesNotModifyAvailableThings()
        {
            var model = new HttpCharacterModel
            {
                CompletionStep = 5,
                AvailableRaces = new[] {"race1", "race2"},
                AvailableClasses = new[] {"class1", "class2"},
                AvailableAlignments = new[] {"alignment1", "alignment2"}
            };
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Equal(new[] {"race1", "race2"}, result.AvailableRaces);
            Assert.Equal(new[] {"class1", "class2"}, result.AvailableClasses);
            Assert.Equal(new[] {"alignment1", "alignment2"}, result.AvailableAlignments);
        }
    }
}