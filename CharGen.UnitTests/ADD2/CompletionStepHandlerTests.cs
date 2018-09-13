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
        public void CompletionStep1_DoesNotModifyAvailableRacesOrClasses()
        {
            var model = new HttpCharacterModel {CompletionStep = 1};
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Null(result.AvailableRaces);
            Assert.Null(result.AvailableClasses);
        }

        [Fact]
        public void CompletionStepAbove3_DoesNotModifyAvailableRacesOrClasses()
        {
            var model = new HttpCharacterModel
            {
                CompletionStep = 4, AvailableRaces = new[] {"race1", "race2"},
                AvailableClasses = new[] {"class1", "class2"}
            };
            var handler = new CompletionStepHandler(model);

            var result = handler.Handle();

            Assert.Equal(new[] {"race1", "race2"}, result.AvailableRaces);
            Assert.Equal(new[] {"class1", "class2"}, result.AvailableClasses);
        }
    }
}