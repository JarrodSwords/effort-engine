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
        private readonly ICommandHandler<DeleteCharacter> _deleteCharacterHandler;
        private readonly IQueryHandler<FetchCharacters, IEnumerable<Character>> _fetchCharactersHandler;
        private readonly IQueryHandler<FindCharacter, Character> _findCharacterHandler;

        #region Creation

        public CharacterController(
            ICommandHandler<DeleteCharacter> deleteCharacterHandler,
            IQueryHandler<FetchCharacters, IEnumerable<Character>> fetchCharactersHandler,
            IQueryHandler<FindCharacter, Character> findCharacterHandler
        )
        {
            _deleteCharacterHandler = deleteCharacterHandler;
            _fetchCharactersHandler = fetchCharactersHandler;
            _findCharacterHandler = findCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpDelete]
        [Route("{name}")]
        public IActionResult DeleteCharacter(string name)
        {
            _deleteCharacterHandler.Handle(new DeleteCharacter(name));

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Character>> FetchCharacters()
        {
            var characters = _fetchCharactersHandler.Handle(new FetchCharacters());

            return Ok(characters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Character> FindCharacter(string name)
        {
            var character = _findCharacterHandler.Handle(new FindCharacter(name));

            return Ok(character);
        }

        #endregion
    }
}
