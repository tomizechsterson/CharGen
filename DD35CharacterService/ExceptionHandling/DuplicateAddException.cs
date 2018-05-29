namespace DD35CharacterService.ExceptionHandling
{
    public class DuplicateAddException : System.Exception
    {
        public DuplicateAddException(string message) : base(message) {}
    }
}