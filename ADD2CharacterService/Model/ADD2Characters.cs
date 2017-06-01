using System.Collections.Generic;

namespace ADD2CharacterService.Model
{
    public interface ADD2Characters
    {
        IEnumerable<ADD2Character> Iterate();
        ADD2Character Get(int id);
        void Add(string name, string playedby);
        void Update(int id, string name, string playedby);
        void Delete(int id);
    }
}