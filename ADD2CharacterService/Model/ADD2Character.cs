namespace ADD2CharacterService.Model
{
    public class ADD2Character
    {
        private readonly string _name;

        public ADD2Character() : this("") {}

        public ADD2Character(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}