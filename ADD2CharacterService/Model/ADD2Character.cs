namespace ADD2CharacterService.Model
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
        HttpCharacterModel ToModel();
    }
}