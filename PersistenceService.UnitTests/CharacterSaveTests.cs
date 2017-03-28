using PersistenceService.UnitTests.TestDoubles;
using Xunit;

namespace PersistenceService.UnitTests
{
    public class CharacterSaveTests
    {
        // CharacterSave object
        // Data store object
        [Fact]
        public void Save_NewCharacter_SaveDataStoreMethodNotCalled()
        {
            var dataStore = new DataStoreMock();
            var characterSave = new CharacterSave(dataStore, null);

            characterSave.Save();

            Assert.False(dataStore.SaveCalled());
        }

        [Fact]
        public void Save_CharacterWithName_SaveDataStoreMethodCalled()
        {
            var dataStore = new DataStoreMock();
            var characterSave = new CharacterSave(dataStore, "testname");

            characterSave.Save();

            Assert.True(dataStore.SaveCalled());
        }
    }
}