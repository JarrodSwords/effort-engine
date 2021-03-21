using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetCharacters()
        {
            return Ok(new List<Character>());
        }
    }
}
