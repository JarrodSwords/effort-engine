using Microsoft.AspNetCore.Mvc;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetCharacters()
        {
            return Ok();
        }
    }
}
