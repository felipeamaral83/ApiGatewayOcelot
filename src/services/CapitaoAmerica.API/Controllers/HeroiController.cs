using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace CapitaoAmerica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Capitão América";
            vingador.Ator = "Chris Evans";

            return Ok(vingador);
        }
    }
}
