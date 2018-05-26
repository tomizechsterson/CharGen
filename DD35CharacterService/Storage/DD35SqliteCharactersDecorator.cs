using Microsoft.Data.Sqlite;

namespace DD35CharacterService.Storage
{
    public abstract class DD35SqliteCharactersDecorator : DD35Characters
    {
        private readonly DD35SqliteCharacters _characters;

        protected DD35SqliteCharactersDecorator(DD35SqliteCharacters characters)
        {
            _characters = characters;
        }

        protected DD35SqliteCharactersDecorator(string connectionString) {}

        public virtual CharacterTransferModel Get(long id)
        {
            return _characters.Get(id);
        }

        public virtual long Add(CharacterTransferModel model)
        {
            return _characters.Add(model);
        }

        public virtual void Update(long id, CharacterTransferModel model)
        {
            _characters.Update(id, model);
        }

        protected static CharacterTransferModel GetResult(long id, SqliteConnection conn)
        {
            return DD35SqliteCharacters.Get(id, conn);
        }

        protected static long Add(CharacterTransferModel model, SqliteConnection conn)
        {
            return DD35SqliteCharacters.Add(model, conn);
        }

        protected static void Update(long id, CharacterTransferModel model, SqliteConnection conn)
        {
            DD35SqliteCharacters.Update(id, model, conn);
        }
    }
}