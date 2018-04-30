namespace ADD2CharacterService.Datastore
{
    public interface ADD2Character
    {
        int Id();
        string Name();
        string PlayedBy();
        int Str();
        int Dex();
        int Con();
        int Int();
        int Wis();
        int Chr();
        string Race();
        HttpCharacterModel ToModel();
    }
}