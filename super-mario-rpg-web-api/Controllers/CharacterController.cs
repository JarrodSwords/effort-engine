using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICommandHandler<CreateCharacter> _createCharacterHandler;
        private readonly IQueryHandler<FetchCharacters, IEnumerable<CharacterDto>> _fetchCharactersHandler;
        private readonly IQueryHandler<FindCharacter, CharacterDto> _findCharacterHandler;

        #region Creation

        public CharacterController(
            ICommandHandler<CreateCharacter> createCharacterHandler,
            IQueryHandler<FetchCharacters, IEnumerable<CharacterDto>> fetchCharactersHandler,
            IQueryHandler<FindCharacter, CharacterDto> findCharacterHandler
        )
        {
            _createCharacterHandler = createCharacterHandler;
            _fetchCharactersHandler = fetchCharactersHandler;
            _findCharacterHandler = findCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateCharacter([FromBody] CreateCharacterDto args)
        {
            var command = new CreateCharacter(args.Name);
            _createCharacterHandler.Handle(command);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CharacterDto>> FetchCharacters()
        {
            var query = new FetchCharacters();
            var characters = _fetchCharactersHandler.Handle(query);

            return Ok(characters);
        }

        [HttpGet]
        [Route("/{name}")]
        public ActionResult<CharacterDto> FindCharacter(string name)
        {
            var query = new FindCharacter(name);
            var character = _findCharacterHandler.Handle(query);

            return Ok(character);
        }

        #endregion
    }
}
