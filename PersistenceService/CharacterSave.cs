using PersistenceService.Interfaces;

namespace PersistenceService
{
    public class CharacterSave
    {
        private readonly IDataStore _dataStore;
        private readonly string _name;

        public CharacterSave(IDataStore dataStore, string name)
        {
            _dataStore = dataStore;
            _name = name;
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(_name))
                _dataStore.Save(this);
        }
    }
}