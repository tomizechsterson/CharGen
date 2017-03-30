using System.Collections.Generic;
using PersistenceService.Implementations;

namespace PersistenceService.Interfaces
{
    public interface ICharacters
    {
        IEnumerable<ICharacter> Iterate();
        ICharacter Add(string name, int str);
    }
}