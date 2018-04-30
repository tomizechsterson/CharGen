using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Datastore;
using ADD2CharacterService.Race;
using ADD2CharacterService.Stats;
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

        #region Datastore crud ops

        [EnableCors("AnyOrigin")]
        [HttpGet]
        public IEnumerable<HttpCharacterModel> Get()
        {
            return _database.Iterate().Select(a => a.ToModel());
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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _database.Delete(id);
        }

        public void Delete()
        {
            var characters = _database.Iterate();
            foreach (var c in characters)
                _database.Delete(c.Id());
        }

        #endregion

        [EnableCors("AnyOrigin")]
        [HttpGet("rollstats/{statRollingRule}")]
        public List<int[]> RollStats(string statRollingRule)
        {
            return new StatRoll(statRollingRule).RollStats();
        }

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
            return new RacialStatAdjust(selectedRace).Adjustmets();
        }
    }
}