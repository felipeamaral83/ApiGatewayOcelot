using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace HomemDeFerro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Homem de Ferro";
            vingador.Ator = "Robert Downey Jr.";

            return Ok(vingador);
        }
    }
}
