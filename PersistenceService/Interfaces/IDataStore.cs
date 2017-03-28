namespace PersistenceService.Interfaces
{
    public interface IDataStore
    {
        void Save(CharacterSave characterSave);
    }
}