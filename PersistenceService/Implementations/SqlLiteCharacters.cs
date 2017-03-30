using System.Collections.Generic;
using PersistenceService.Interfaces;

namespace PersistenceService.Implementations
{
    public class SqlLiteCharacters : ICharacters
    {
        public IEnumerable<ICharacter> Iterate()
        {
            // Do query into database that returns
            // objects that implement ICharacter
            throw new System.NotImplementedException();
        }

        public ICharacter Add(string name, int str)
        {
            // Do query that inserts into database
            // and returns the object inserted
            // which also implements ICharacter
            throw new System.NotImplementedException();
        }
    }
}