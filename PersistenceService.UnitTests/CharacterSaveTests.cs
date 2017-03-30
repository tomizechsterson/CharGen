using Xunit;

namespace PersistenceService.UnitTests
{
    public class CharacterSaveTests
    {
        // Character object
        // Data store object
        [Fact]
        public void Save_NewCharacter_SaveDataStoreMethodNotCalled()
        {
            var character = new Character();

            character.Save();

//            Assert.False(dataStore.SaveCalled());
        }

        [Fact]
        public void Save_CharacterWithName_SaveDataStoreMethodCalled()
        {
            var character = new Character("testname");

            character.Save();

//            Assert.True(dataStore.SaveCalled());
        }
    }
}