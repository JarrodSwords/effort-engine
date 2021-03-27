using System.Collections.Generic;
using Effort.Domain;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        #region Creation

        public CharacterController(IDispatcher dispatcher)
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
        public ActionResult<IEnumerable<CharacterDto>> FetchCharacters()
        {
            var cmd = new FetchCharacters();
            var characters = _dispatcher.Dispatch(cmd);

            return Ok(characters);
        }

        [HttpGet]
        [Route("/{recordName}")]
        public ActionResult<CharacterDto> FindCharacter(string recordName)
        {
            var cmd = new FindCharacter(recordName);
            var character = _dispatcher.Dispatch(cmd);

            return Ok(character);
        }

        #endregion
    }
}
