using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADD2CharacterService.Datastore
{
    public interface ADD2Characters
    {
        Task<IEnumerable<ADD2Character>> Iterate();
        ADD2Character Get(int id);
        Task Add(HttpCharacterModel model);
        Task Update(int id, HttpCharacterModel model);
        Task Delete(int id);
    }
}