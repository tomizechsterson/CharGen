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
        private const string Db = "Data Source=characters";

        [EnableCors("SpecificOrigin")]
        [HttpGet]
        public IEnumerable<HttpCharacterModel> Get()
        {
            return new ADD2SqliteCharacters(Db).Iterate().Select(a => a.ToModel());
        }

        [EnableCors("SpecificOrigin")]
        [HttpGet("{id}")]
        public ADD2Character Get(int id)
        {
            return new ADD2SqliteCharacters(Db).Get(id);
        }

        [EnableCors("SpecificOrigin")]
        [Route("new")]
        [HttpPost]
        public void Post(HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(Db).Add(characterModel);
        }

        [EnableCors("SpecificOrigin")]
        [HttpPut("{id}")]
        public void Put(int id, HttpCharacterModel characterModel)
        {
            new ADD2SqliteCharacters(Db).Update(id, characterModel);
        }

        [EnableCors("SpecificOrigin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ADD2SqliteCharacters(Db).Delete(id);
        }

        public void Delete()
        {
            var characters = new ADD2SqliteCharacters(Db).Iterate();
            foreach (var c in characters)
                new ADD2SqliteCharacters(Db).Delete(c.Id());
        }
    }
}
