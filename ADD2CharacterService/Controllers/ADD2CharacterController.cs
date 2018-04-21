using System;
using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Model;
using ADD2CharacterService.Stats;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADD2CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class ADD2CharacterController : Controller
    {
        private readonly ADD2Characters _database;
        
        public ADD2CharacterController() : this(new ADD2SqliteCharacters("Data Source=characters")) {}

        public ADD2CharacterController(ADD2Characters database)
        {
            _database = database;
        }
#region Datastore crud ops
        [EnableCors("SpecificOrigin")]
        [HttpGet]
        public IEnumerable<HttpCharacterModel> Get()
        {
            return _database.Iterate().Select(a => a.ToModel());
        }

        [EnableCors("SpecificOrigin")]
        [HttpGet("{id}")]
        public ADD2Character Get(int id)
        {
            return _database.Get(id);
        }

        [EnableCors("SpecificOrigin")]
        [Route("new")]
        [HttpPost]
        public void Post(HttpCharacterModel characterModel)
        {
            _database.Add(characterModel);
        }

        [EnableCors("SpecificOrigin")]
        [HttpPut("{id}")]
        public void Put(int id, HttpCharacterModel characterModel)
        {
            _database.Update(id, characterModel);
        }

        [EnableCors("SpecificOrigin")]
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
        // will eventually delete DiceService
        public List<int[]> RollStats(StatRollingRule statRollingRule)
        {
            switch (statRollingRule)
            {
                case StatRollingRule.RollOnce:
                    return new List<int[]>(6)
                    {
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 },
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 }
                    };
                case StatRollingRule.RollTwice:
                    return new List<int[]>(12)
                    {
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 },
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 },
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 },
                        new[] { 1, 1, 1 }, new[] { 1, 1, 1 }, new[] { 1, 1, 1 }
                    };
                case StatRollingRule.Assignment:
                    return new List<int[]>(6)
                    {
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 },
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 }
                    };
                case StatRollingRule.AssignmentDouble:
                    return new List<int[]>(12)
                    {
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 },
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 },
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 },
                        new[] { 6, 6, 6 }, new[] { 6, 6, 6 }, new[] { 6, 6, 6 }
                    };
                case StatRollingRule.RollFour:
                    return new List<int[]>(6)
                    {
                        new[] { 6, 6, 6, 6 }, new[] { 6, 6, 6, 6 }, new[] { 6, 6, 6, 6 },
                        new[] { 6, 6, 6, 6 }, new[] { 6, 6, 6, 6 }, new[] { 6, 6, 6, 6 }
                    };
                case StatRollingRule.AddSevenDice:
                    return new List<int[]>(7)
                    {
                        new[] { 1 }, new[] { 1 }, new[] { 1 },
                        new[] { 1 }, new[] { 1 }, new[] { 1 }, new[] { 1 }
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(statRollingRule), statRollingRule,
                        "The rule to use for rolling stats needs to be one of the six defined in the Player's Handbook");
            }
        }
    }
}
