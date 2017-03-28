using PersistenceService.Interfaces;

namespace PersistenceService.UnitTests.TestDoubles
{
    public class DataStoreMock : IDataStore
    {
        private bool _saveCalled;

        public void Save(PersistenceService.CharacterSave characterSave)
        {
            _saveCalled = true;
        }

        public bool SaveCalled()
        {
            return _saveCalled;
        }
    }
}