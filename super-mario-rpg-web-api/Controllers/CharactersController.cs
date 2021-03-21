using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IActionResult GetCharacters()
        {
            var characters = _characterService.Fetch();

            return Ok(characters);
        }
    }
}
