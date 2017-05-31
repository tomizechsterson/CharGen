using System.Collections.Generic;

namespace ADD2CharacterService.Model
{
    public interface ADD2Characters
    {
        IEnumerable<ADD2Character> iterate();
        ADD2Character add(string name);
    }
}