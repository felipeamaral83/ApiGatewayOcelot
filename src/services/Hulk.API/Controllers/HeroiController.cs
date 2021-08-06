using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Hulk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Hulk";
            vingador.Ator = "Mark Ruffalo";

            return Ok(vingador);
        }
    }
}
