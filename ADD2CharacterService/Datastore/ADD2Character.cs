namespace ADD2CharacterService.Datastore
{
    public interface ADD2Character
    {
        int Id();
        string Name();
        int Str();
        int Dex();
        int Con();
        int Int();
        int Wis();
        int Chr();
        string Race();
        string Gender();
        int Height();
        int Weight();
        int Age();
        string ClassName();
        string Alignment();
        int HP();
        int Paralyze();
        int Rod();
        int Petrification();
        int Breath();
        int Spell();
        int MoveRate();
        int Funds();
        HttpCharacterModel ToModel();
    }
}