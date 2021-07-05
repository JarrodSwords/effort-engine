using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write.Characters.Playable;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/playable-characters")]
    [ApiController]
    public class PlayableCharacterController : ControllerBase
    {
        private readonly IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>>
            _fetchPlayableCharacterHandler;

        private readonly IQueryHandler<FindPlayableCharacter, PlayableCharacter> _findPlayableCharacterHandler;
        private readonly ICommandHandler<UpdateBaseStats> _updateBaseStatsHandler;

        #region Creation

        public PlayableCharacterController(
            IQueryHandler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>> fetchPlayableCharacterHandler,
            IQueryHandler<FindPlayableCharacter, PlayableCharacter> findPlayableCharacterHandler,
            ICommandHandler<UpdateBaseStats> updateBaseStatsHandler
        )
        {
            _fetchPlayableCharacterHandler = fetchPlayableCharacterHandler;
            _findPlayableCharacterHandler = findPlayableCharacterHandler;
            _updateBaseStatsHandler = updateBaseStatsHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<PlayableCharacter>> Fetch()
        {
            var playableCharacters = _fetchPlayableCharacterHandler.Handle(new FetchPlayableCharacters());

            return Ok(playableCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<PlayableCharacter> Find(string name)
        {
            var playableCharacter = _findPlayableCharacterHandler.Handle(new FindPlayableCharacter(name));

            return Ok(playableCharacter);
        }

        [HttpPut]
        [Route("{name}/base-stats")]
        public IActionResult UpdateBaseStats(
            string name,
            [FromBody] PlayableCharacterCombatStats baseStats
        )
        {
            var (hitPoints, speed, attack, magicAttack, defense, magicDefense) = baseStats;

            _updateBaseStatsHandler.Handle(
                new UpdateBaseStats(
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
