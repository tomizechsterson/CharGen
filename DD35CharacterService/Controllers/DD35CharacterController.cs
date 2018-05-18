using System.Collections.Generic;
using DD35CharacterService.App.Stats;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DD35CharacterService.Controllers
{
    [Route("api/[controller]")]
    public class DD35CharacterController : Controller
    {
        [EnableCors("AnyOrigin")]
        [HttpGet("test")]
        public string Test()
        {
            return "HAI!";
        }

        public List<int[]> RollStats()
        {
            return new DD35StatRoll().RollStats();
        }
    }
}