using System.Collections.Generic;
using System.Threading.Tasks;
using DD35CharacterService.App;
using DD35CharacterService.App.HeightWeight;
using DD35CharacterService.App.Stats;
using DD35CharacterService.Storage;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DD35CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class DD35CharacterController : Controller
    {
        private readonly DD35Characters _storage;

        public DD35CharacterController(DD35Characters storage = null)
        {
            _storage = storage ?? new DD35SqliteCharacters("DataSource=characters");
        }

        [EnableCors("AnyOrigin")]
        public async Task<CharacterTransferModel[]> Get()
        {
            return await _storage.Get();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("{id}")]
        public async Task<CharacterTransferModel> Get(int id)
        {
            return await _storage.Get(id);
        }

        [EnableCors("AnyOrigin")]
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] CharacterTransferModel model)
        {
            await _storage.Update(id, model);
        }

        [EnableCors("AnyOrigin")]
        [HttpPost]
        public async Task Insert([FromBody] CharacterTransferModel model)
        {
            await _storage.Add(model);
        }

        [EnableCors("AnyOrigin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _storage.Delete(id);
        }

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
            return new[]
            {
                "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", 
                "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard"
            };
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

        [EnableCors("AnyOrigin")]
        [HttpGet("age/{race}/{className}")]
        public int StartingAge(string race, string className)
        {
            return new StartingAge(race, className).Get();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("hw/{race}/{gender}")]
        public int[] StartingHeightWeight(string race, string gender)
        {
            return new StartingHeightWeight(race, gender).Get();
        }
    }
}