using Effort.Domain;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        #region Creation

        public CharactersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateCharacter([FromBody] CreateCharacterDto dto)
        {
            var cmd = new CreateCharacter(dto.Name);
            _dispatcher.Dispatch(cmd);

            return Ok();
        }

        [HttpGet]
        [Route("/{recordName}")]
        public ActionResult<CharacterDto> GetCharacter(string recordName)
        {
            var cmd = new FetchCharacter(recordName);
            var character = _dispatcher.Dispatch(cmd);

            return Ok(character);
        }

        [HttpGet]
        public IActionResult GetCharacters()
        {
            var cmd = new FetchCharacters();
            var characters = _dispatcher.Dispatch(cmd);

            return Ok(characters);
        }

        #endregion
    }
}
