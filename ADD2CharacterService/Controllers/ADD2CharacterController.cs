using System;
using System.Collections.Generic;
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
        private readonly Random _random;

        public ADD2CharacterController(ADD2Characters database = null)
        {
            _database = database ?? new ADD2SqliteCharacters("Data Source=characters");
            _random = new Random(Environment.TickCount);
        }

        #region Datastore Crud Ops

        [EnableCors("AnyOrigin")]
        [HttpGet]
        public async Task<IEnumerable<HttpCharacterModel>> Get()
        {
            var allChars = await _database.Iterate();
            var models = new List<HttpCharacterModel>();
            foreach (var add2Character in allChars)
                models.Add(await add2Character.ToModel());

            return models;
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("{id}")]
        public async Task<HttpCharacterModel> Get(int id)
        {
            return await _database.Get(id).ToModel();
        }

        [EnableCors("AnyOrigin")]
        [HttpPost]
        public async Task Post([FromBody] HttpCharacterModel characterModel)
        {
            await _database.Add(characterModel);
        }

        [EnableCors("AnyOrigin")]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] HttpCharacterModel characterModel)
        {
            await _database.Update(id, new CompletionStepHandler(characterModel).Handle());
        }

        [EnableCors("AnyOrigin")]
        [HttpPut("{id}/final")]
        public async Task FinalUpdate(int id, [FromBody] HttpCharacterModel characterModel)
        {
            characterModel.HP = new HP(characterModel.ClassName, _random).Get();
            var savingThrows = new SavingThrows(characterModel.ClassName).Get();
            characterModel.Paralyze = savingThrows[0];
            characterModel.Rod = savingThrows[1];
            characterModel.Petrification = savingThrows[2];
            characterModel.Breath = savingThrows[3];
            characterModel.Spell = savingThrows[4];
            characterModel.MoveRate = new MovementRate(characterModel.Race).Get();
            characterModel.Funds = new Funds(characterModel.ClassName, _random).Get();
            await _database.Update(id, characterModel);
        }

        [EnableCors("AnyOrigin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _database.Delete(id);
        }

        public async Task Delete()
        {
            var characters = await _database.Iterate();
            foreach (var c in characters)
                await _database.Delete(c.Id());
        }

        #endregion

        #region Stats

        [EnableCors("AnyOrigin")]
        [HttpGet("rollstats/{statRollingRule}")]
        public List<int[]> RollStats(string statRollingRule)
        {
            return new StatRoll(statRollingRule, _random).RollStats();
        }

        [EnableCors("AnyOrigin")]
        [HttpGet("final/{race}/{className}")]
        public int[] GetFinalAttributes(string race, string className)
        {
            var result = new List<int> {new MovementRate(race).Get()};
            result.AddRange(new SavingThrows(className).Get());
            return result.ToArray();
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
                new HeightWeightAge(race, gender, _random).Height(),
                new HeightWeightAge(race, gender, _random).Weight(),
                new HeightWeightAge(race, gender, _random).Age()
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

        [EnableCors("AnyOrigin")]
        [HttpGet("hpgp/{className}")]
        public int[] GetInitialHPGP(string className)
        {
            return new[] {new HP(className, _random).Get(), new Funds(className, _random).Get()};
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