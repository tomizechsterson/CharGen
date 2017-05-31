using System.Collections.Generic;
using ADD2CharacterService.Model;
using Microsoft.AspNetCore.Mvc;

namespace ADD2CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class ADD2CharacterController : Controller
    {
        private string _db = "Data Source=characters";

        // GET api/ADD2Character
//        public IEnumerable<string> Get()
        [HttpGet]
        public IEnumerable<ADD2Character> Get()
        {
            return new ADD2SqliteCharacters(_db).Iterate();
//            return new string[] { "value1", "value2" };
        }

        // GET api/ADD2Character/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ADD2Character
        [HttpPost]
        public void Post([FromBody]string name, string playedby)
        {
            new ADD2SqliteCharacters(_db).Add(name, playedby);
        }

        // PUT api/ADD2Character/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ADD2Character/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
