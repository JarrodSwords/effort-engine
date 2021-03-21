using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        #region Creation

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        [Route("/{recordName}")]
        public ActionResult<CharacterDto> GetCharacter(string recordName)
        {
            var character = _characterService.Fetch(recordName);

            return Ok(character);
        }

        [HttpGet]
        public IActionResult GetCharacters()
        {
            var characters = _characterService.Fetch();

            return Ok(characters);
        }

        #endregion
    }
}
