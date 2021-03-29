using System.Collections.Generic;
using Effort.Domain;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateCharacter([FromBody] CreateCharacter.Args args)
        {
            var cmd = new CreateCharacter(args.Name);
            _createCharacterHandler.Handle(cmd);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CharacterDto>> FetchCharacters()
        {
            var cmd = new FetchCharacters();
            var characters = _fetchCharactersHandler.Handle(cmd);

            return Ok(characters);
        }

        [HttpGet]
        [Route("/{recordName}")]
        public ActionResult<CharacterDto> FindCharacter(string recordName)
        {
            var cmd = new FindCharacter(recordName);
            var character = _findCharacterHandler.Handle(cmd);

            return Ok(character);
        }

        #endregion
    }
}
