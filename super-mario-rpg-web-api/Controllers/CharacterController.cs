using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IQueryHandler<FetchCharacters, IEnumerable<object>> _fetchCharactersHandler;
        private readonly IQueryHandler<FindCharacter, Character> _findCharacterHandler;

        #region Creation

        public CharacterController(
            IQueryHandler<FetchCharacters, IEnumerable<object>> fetchCharactersHandler,
            IQueryHandler<FindCharacter, Character> findCharacterHandler
        )
        {
            _fetchCharactersHandler = fetchCharactersHandler;
            _findCharacterHandler = findCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<object>> FetchCharacters()
        {
            var query = new FetchCharacters();
            var characters = _fetchCharactersHandler.Handle(query);

            return Ok(characters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Character> FindCharacter(string name)
        {
            var query = new FindCharacter(name);
            var character = _findCharacterHandler.Handle(query);

            return Ok(character);
        }

        #endregion
    }
}
