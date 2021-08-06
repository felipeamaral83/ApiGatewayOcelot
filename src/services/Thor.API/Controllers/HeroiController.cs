using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Thor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Thor";
            vingador.Ator = "Chris Hemsworth";

            return Ok(vingador);
        }
    }
}
