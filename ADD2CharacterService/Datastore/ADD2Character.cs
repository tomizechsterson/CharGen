using System.Threading.Tasks;

namespace ADD2CharacterService.Datastore
{
    public interface ADD2Character
    {
        int Id();
        Task<string> Name();
        Task<int> Str();
        Task<int> Dex();
        Task<int> Con();
        Task<int> Int();
        Task<int> Wis();
        Task<int> Chr();
        Task<string> Race();
        Task<string> AvailableRaces();
        Task<string> Gender();
        Task<int> Height();
        Task<int> Weight();
        Task<int> Age();
        Task<string> ClassName();
        Task<string> Alignment();
        Task<int> HP();
        Task<int> Paralyze();
        Task<int> Rod();
        Task<int> Petrification();
        Task<int> Breath();
        Task<int> Spell();
        Task<int> MoveRate();
        Task<int> Funds();
        Task<HttpCharacterModel> ToModel();
    }
}