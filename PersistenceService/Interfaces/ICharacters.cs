using System.Collections.Generic;

namespace PersistenceService.Interfaces
{
    public interface ICharacters
    {
        IEnumerable<Character> Iterate();
        Character Add(string name);
    }
}