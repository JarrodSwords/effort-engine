using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/playable-characters")]
    [ApiController]
    public class PlayableCharacterController : ControllerBase
    {
        private readonly IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>>
            _fetchPlayableCharactersHandler;

        private readonly IQueryHandler<FindPlayableCharacter, PlayableCharacter> _findPlayableCharacterHandler;
        private readonly ICommandHandler<UpdatePlayableCharacterBaseStats> _updatePlayableCharacterCombatStats;

        #region Creation

        public PlayableCharacterController(
            IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>> fetchPlayableCharactersHandler,
            IQueryHandler<FindPlayableCharacter, PlayableCharacter> findPlayableCharacterHandler,
            ICommandHandler<UpdatePlayableCharacterBaseStats> updatePlayableCharacterCombatStats
        )
        {
            _fetchPlayableCharactersHandler = fetchPlayableCharactersHandler;
            _findPlayableCharacterHandler = findPlayableCharacterHandler;
            _updatePlayableCharacterCombatStats = updatePlayableCharacterCombatStats;
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

        [HttpPut]
        [Route("{name}/base-stats")]
        public IActionResult UpdatePlayableCharacterBaseStats(
            string name,
            [FromBody] PlayableCharacterCombatStats baseStats
        )
        {
            var (hitPoints, speed, attack, magicAttack, defense, magicDefense) = baseStats;

            _updatePlayableCharacterCombatStats.Handle(
                new UpdatePlayableCharacterBaseStats(
                    name,
                    hitPoints,
                    speed,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense
                )
            );

            return Ok();
        }

        #endregion
    }
}
