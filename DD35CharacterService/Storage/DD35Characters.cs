namespace DD35CharacterService.Storage
{
    public interface DD35Characters
    {
        CharacterTransferModel Get(long id);
        long Add(CharacterTransferModel model);
    }
}