using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public ADD2Character Get(int id)
        {
            return new ADD2SqliteCharacters(_db).Get(id);
        }

        [HttpPost]
        public void Post([FromBody]HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(_db).Add(characterModel.Name, characterModel.PlayedBy);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(_db).Update(id, characterModel.Name, characterModel.PlayedBy);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ADD2SqliteCharacters(_db).Delete(id);
        }
    }
}
