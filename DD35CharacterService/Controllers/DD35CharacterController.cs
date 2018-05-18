using System.Collections.Generic;
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

        public string[] Races()
        {
            return new[] { "Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human" };
        }

        public string[] Classes()
        {
            return new[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard" };
        }

        public Dictionary<string, int> StatAdjustments(string race)
        {
            return new Dictionary<string, int>();
        }
    }
}