﻿using System;
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

        [EnableCors("SpecificOrigin")]
        [HttpGet("{statRollingRule}")]
        public List<int[]> RollStats(string statRollingRule)
        {
            if (Enum.TryParse<StatRollingRule>(statRollingRule, true, out var rule))
                return new StatRoll(rule).RollStats();

            throw new ArgumentOutOfRangeException(nameof(statRollingRule), statRollingRule,
                "The rule to use for rolling stats needs to be one of the six defined in the Player's Handbook");
        }

        [EnableCors("SpecificOrigin")]
        [HttpGet("{statRollingRule}")]
        public string[] RacesAvailable([FromBody] HttpCharacterModel characterModel)
        {
            return new string[3];
        }
    }
}