namespace ADD2CharacterService.Datastore
{
    public class HttpCharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Chr { get; set; }
        public string Race { get; set; }
        public string[] AvailableRaces { get; set; }
        public string Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string ClassName { get; set; }
        public string[] AvailableClasses { get; set; }
        public string Alignment { get; set; }
        public int HP { get; set; }
        public int Paralyze { get; set; }
        public int Rod { get; set; }
        public int Petrification { get; set; }
        public int Breath { get; set; }
        public int Spell { get; set; }
        public int MoveRate { get; set; }
        public int Funds { get; set; }

        public int CompletionStep { get; set; }
    }
}