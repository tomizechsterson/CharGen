using System.Collections.Generic;

namespace ADD2CharacterService.App
{
    public class AllowedAlignments
    {
        private readonly string _className;
        private readonly Dictionary<string, string[]> _allowedAlignments;

        public AllowedAlignments(string className)
        {
            _className = className.Replace("%2F", "/");
            _allowedAlignments = InitializeAlignments();
        }

        public string[] Get()
        {
            return _className.Contains("/") ? AllAlignments() : _allowedAlignments[_className];
        }

        private static Dictionary<string, string[]> InitializeAlignments()
        {
            return new Dictionary<string, string[]>
            {
                { "Paladin", new[] { "Lawful Good" } },
                { "Druid", new[] {"True Neutral"} },
                { "Ranger", new[] { "Lawful Good", "Neutral Good", "Chaotic Good" } },
                { "Bard", new[] { "Lawful Neutral", "Neutral Good", "True Neutral", "Neutral Evil", "Chaotic Neutral" } },
                { "Fighter", AllAlignments() },
                { "Mage", AllAlignments() },
                { "Cleric", AllAlignments() },
                { "Thief", AllAlignments() }
            };
        }

        private static string[] AllAlignments()
        {
            return new[]
            {
                "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral",
                "Lawful Evil", "Neutral Evil", "Chaotic Evil"
            };
        }
    }
}