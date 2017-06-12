namespace ADD2CharacterService.Model
{
    public class HttpCharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayedBy { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Chr { get; set; }

        public bool IsCompleted { get; set; }
    }
}