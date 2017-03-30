using PersistenceService.Interfaces;

namespace PersistenceService.Implementations
{
    public class Character : ICharacter
    {
        private readonly int _id;
        private readonly string _name;
        private readonly int _strength;

        public Character() : this(0, "", 0) {}

        public Character(int id, string name, int strength)
        {
            _id = id;
            _name = name;
            _strength = strength;
        }

        public int Id()
        {
            return _id;
        }

        public string Name()
        {
            return _name;
        }

        public int Strength()
        {
            return _strength;
        }
    }
}