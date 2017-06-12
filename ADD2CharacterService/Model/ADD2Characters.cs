using System.Collections.Generic;

namespace ADD2CharacterService.Model
{
    public interface ADD2Characters
    {
        IEnumerable<ADD2Character> Iterate();
        ADD2Character Get(int id);
        void Add(HttpCharacterModel model);
        void Update(int id, HttpCharacterModel model);
        void Delete(int id);
    }
}