namespace PersistenceService
{
    public class Character
    {
        private readonly string _name;


        public Character() : this("") {}

        public Character(string name)
        {
            _name = name;
        }


        public void Save()
        {
            if (!string.IsNullOrEmpty(_name)) {}
//                _dataStore.Save(this);
        }
    }
}