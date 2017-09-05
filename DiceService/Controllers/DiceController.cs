using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DiceService.App;
using Microsoft.AspNetCore.Cors;

namespace DiceService.Controllers
{
    [Route("api/[controller]")]
    public class DiceController : Controller
    {
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new Roll(1, 6).DoRoll();
        }

        [EnableCors("SpecificOrigin")]
        [HttpGet("{times}/{sides}")]
        public IEnumerable<int> Get(int times, int sides)
        {
            return new Roll(times, sides).DoRoll();
        }
    }
}
