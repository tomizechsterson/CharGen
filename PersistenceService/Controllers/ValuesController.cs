using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PersistenceService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // Passing requests into application
        // Returning web responses
        // Each method should handle one and only one type of request

        // Web controller methods must not contain any selection logic
        // Web methods must not perform any logging
        // custom serialization must be centralized -- do not handle it in the controller

        // Only a single line of code allowed!

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // api/{name}/Get ?
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
