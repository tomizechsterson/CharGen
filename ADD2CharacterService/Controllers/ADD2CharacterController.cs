using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADD2CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class ADD2CharacterController : Controller
    {
        private const string _db = "Data Source=characters";

        [EnableCors("AllowEverything")]
        [HttpGet]
        public IEnumerable<HttpCharacterModel> Get()
        {
            return new ADD2SqliteCharacters(_db).Iterate().Select(a => a.ToModel());
        }

        [EnableCors("AllowEverything")]
        [HttpGet("{id}")]
        public ADD2Character Get(int id)
        {
            return new ADD2SqliteCharacters(_db).Get(id);
        }

        [EnableCors("AllowEverything")]
        [Route("new")]
        [HttpPost]
        public void Post(HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(_db).Add(characterModel.Name, characterModel.PlayedBy);
        }

        [EnableCors("AllowEverything")]
        [HttpPut("{id}")]
        public void Put(int id, HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(_db).Update(id, characterModel.Name, characterModel.PlayedBy);
        }

        [EnableCors("AllowEverything")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ADD2SqliteCharacters(_db).Delete(id);
        }
    }
}
