using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADD2CharacterService.App;
using ADD2CharacterService.App.CharacterClass;
using ADD2CharacterService.App.Race;
using ADD2CharacterService.App.Stats;
using ADD2CharacterService.Datastore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADD2CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class ADD2CharacterController : Controller
    {
        private readonly ADD2Characters _database;

        public ADD2CharacterController(ADD2Characters database = null)
        {
            _database = database ?? new ADD2SqliteCharacters("Data Source=characters");
        }

        #region Datastore Crud Ops

        [EnableCors("AnyOrigin")]
        [HttpGet]
        public async Task<IEnumerable<HttpCharacterModel>> Get()
        {
            return (await _database.Iterate()).Select(a => a.ToModel());
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("{id}")]
        public HttpCharacterModel Get(int id)
        {
            return _database.Get(id).ToModel();
        }

        [EnableCors("AnyOrigin")]
        [Route("new")]
        [HttpPost]
        public void Post([FromBody] HttpCharacterModel characterModel)
        {
            _database.Add(characterModel);
        }

        [EnableCors("AnyOrigin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] HttpCharacterModel characterModel)
        {
            _database.Update(id, characterModel);
        }

        [EnableCors("AnyOrigin")]
        [HttpPut("{id}/final")]
        public void FinalUpdate(int id, [FromBody] HttpCharacterModel characterModel)
        {
            characterModel.HP = new HP(characterModel.ClassName).Get();
            var savingThrows = new SavingThrows(characterModel.ClassName).Get();
            characterModel.Paralyze = savingThrows[0];
            characterModel.Rod = savingThrows[1];
            characterModel.Petrification = savingThrows[2];
            characterModel.Breath = savingThrows[3];
            characterModel.Spell = savingThrows[4];
            characterModel.MoveRate = new MovementRate(characterModel.Race).Get();
            characterModel.Funds = new Funds(characterModel.ClassName).Get();
            _database.Update(id, characterModel);
        }

        [EnableCors("AnyOrigin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _database.Delete(id);
        }

        public async Task Delete()
        {
            var characters = await _database.Iterate();
            foreach (var c in characters)
                _database.Delete(c.Id());
        }

        #endregion

        #region Stats

        [EnableCors("AnyOrigin")]
        [HttpGet("rollstats/{statRollingRule}")]
        public List<int[]> RollStats(string statRollingRule)
        {
            return new StatRoll(statRollingRule).RollStats();
        }

        #endregion

        #region Race Stuff

        [EnableCors("AnyOrigin")]
        [HttpGet("races/{str}/{dex}/{con}/{int}/{wis}/{chr}")]
        public string[] RacesAvailable(int str, int dex, int con, int @int, int wis, int chr)
        {
            return new AvailableRaces(str, dex, con, @int, wis, chr).Select();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("statadjust/{selectedRace}")]
        public Dictionary<string, int> GetStatAdjustments(string selectedRace)
        {
            return new RacialStatAdjust(selectedRace).Adjustments();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("hwa/{race}/{gender}")]
        public int[] GetHeightWeightAge(string race, string gender)
        {
            return new[]
            {
                new HeightWeightAge(race, gender).Height(),
                new HeightWeightAge(race, gender).Weight(),
                new HeightWeightAge(race, gender).Age()
            };
        }

        #endregion

        #region Class Stuff

        [EnableCors("AnyOrigin")]
        [HttpGet("classes/{race}/{str}/{dex}/{con}/{int}/{wis}/{chr}")]
        public string[] GetClasses(string race, int str, int dex, int con, int @int, int wis, int chr)
        {
            return new AvailableClasses(race, str, dex, con, @int, wis, chr).Select();
        }

        #endregion

        #region Alignment

        [EnableCors("AnyOrigin")]
        [HttpGet("alignment/{className}")]
        public string[] Alignments(string className)
        {
            return new AllowedAlignments(className).Get();
        }

        #endregion
    }
}