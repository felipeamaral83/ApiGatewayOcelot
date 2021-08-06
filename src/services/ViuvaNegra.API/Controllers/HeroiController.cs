using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ViuvaNegra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Viúva Negra";
            vingador.Ator = "Scarlett Johansson";

            return Ok(vingador);
        }
    }
}
