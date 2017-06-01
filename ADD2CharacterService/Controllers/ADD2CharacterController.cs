﻿using System.Collections.Generic;
using ADD2CharacterService.Model;
using Microsoft.AspNetCore.Mvc;

namespace ADD2CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class ADD2CharacterController : Controller
    {
        private const string _db = "Data Source=characters";

        [HttpGet]
        public IEnumerable<ADD2Character> Get()
        {
            return new ADD2SqliteCharacters(_db).Iterate();
        }

        // GET api/ADD2Character/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ADD2Character
        [HttpPost]
        public void Post([FromBody]HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(_db).Add(characterModel.Name, characterModel.PlayedBy);
        }

        // PUT api/ADD2Character/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]HttpCharacterModel characterModel)
        {
        }

        // DELETE api/ADD2Character/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
