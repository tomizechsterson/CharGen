using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DiceService.Controllers
{
    [Route("api/[controller]")]
    public class DiceController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{times}/{sides}")]
        public string Get(int times, int sides)
        {
            return "times: " + times + "; sides: " + sides;
        }
    }
}
