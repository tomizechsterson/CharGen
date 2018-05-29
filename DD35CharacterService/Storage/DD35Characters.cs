namespace DD35CharacterService.Storage
{
    public interface DD35Characters
    {
        CharacterTransferModel[] Get();
        CharacterTransferModel Get(long id);
        long Add(CharacterTransferModel model);
        void Update(long id, CharacterTransferModel model);
        void Delete(long id);
    }
}