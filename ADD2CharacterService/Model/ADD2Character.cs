namespace ADD2CharacterService.Model
{
    public interface ADD2Character
    {
        int Id();
        string Name();
        string PlayedBy();
        HttpCharacterModel ToModel();
    }
}