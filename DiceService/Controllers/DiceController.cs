using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DiceService.Controllers
{
    [Route("api/[controller]")]
    public class DiceController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
