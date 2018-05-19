using System.Collections.Generic;
using DD35CharacterService.App;
using DD35CharacterService.App.Stats;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DD35CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class DD35CharacterController : Controller
    {
        [EnableCors("AnyOrigin")]
        [HttpGet("stats")]
        public List<int[]> RollStats()
        {
            return new DD35StatRoll().RollStats();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("races")]
        public string[] Races()
        {
            return new[] { "Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human" };
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("classes")]
        public string[] Classes()
        {
            return new[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard" };
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("statadj/{race}")]
        public Dictionary<string, int> StatAdjustments(string race)
        {
            return new StatAdjust(race).Adjustments();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("algn")]
        public string[] Alignments()
        {
            return new[]
            {
                "Lawful Good", "Lawful Neutral", "Lawful Evil", 
                "Neutral Good", "Neutral", "Neutral Evil", 
                "Chaotic Good", "Chaotic Neutral", "Chaotic Evil"
            };
        }
    }
}