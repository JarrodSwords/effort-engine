using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/playable-characters")]
    [ApiController]
    public class PlayableCharacterController : ControllerBase
    {
        private readonly IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>>
            _fetchPlayableCharactersHandler;

        private readonly IQueryHandler<FindPlayableCharacter, PlayableCharacter> _findPlayableCharacterHandler;

        #region Creation

        public PlayableCharacterController(
            IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>> fetchPlayableCharactersHandler,
            IQueryHandler<FindPlayableCharacter, PlayableCharacter> findPlayableCharacterHandler
        )
        {
            _fetchPlayableCharactersHandler = fetchPlayableCharactersHandler;
            _findPlayableCharacterHandler = findPlayableCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<PlayableCharacter>> FetchPlayableCharacters()
        {
            var playableCharacters = _fetchPlayableCharactersHandler.Handle(new FetchPlayableCharacters());

            return Ok(playableCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<PlayableCharacter> FetchPlayableCharacters(string name)
        {
            var playableCharacter = _findPlayableCharacterHandler.Handle(new FindPlayableCharacter(name));

            return Ok(playableCharacter);
        }

        #endregion
    }
}
