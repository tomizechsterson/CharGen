using PersistenceService.Interfaces;

namespace PersistenceService.Implementations
{
    public class SqlLiteCharacter : ICharacter
    {
//        private readonly DatabaseThingie _dbase;
        private readonly int _id;

        public SqlLiteCharacter() : this(0) {}

        public SqlLiteCharacter(/*DatabaseThingie dbase*/int id)
        {
//            _dbase = _dbase; (data)
            _id = id;
        }

        public int Id()
        {
            return _id;
        }

        public string Name()
        {
            // Do a query into _dbase that gets the
            // name for the object with id == _id
            return "";
        }

        public int Strength()
        {
            // Do a query into _dbase that gets the
            // str value for the object with 
            // id == _id
            return 0;
        }
    }
}