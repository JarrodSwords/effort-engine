using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.Characters.Playable;
using SuperMarioRpg.Application.Write.Characters.Playable;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/playable-characters")]
    [ApiController]
    public class PlayableCharacterController : ControllerBase
    {
        private readonly IQueryHandler<Fetch, IEnumerable<Fetch.PlayableCharacter>> _fetchHandler;
        private readonly IQueryHandler<Find, PlayableCharacter> _findHandler;
        private readonly ICommandHandler<UpdateBaseStats> _updateBaseStatsHandler;

        #region Creation

        public PlayableCharacterController(
            IQueryHandler<Fetch, IEnumerable<Fetch.PlayableCharacter>> fetchHandler,
            IQueryHandler<Find, PlayableCharacter> findHandler,
            ICommandHandler<UpdateBaseStats> updateBaseStatsHandler
        )
        {
            _fetchHandler = fetchHandler;
            _findHandler = findHandler;
            _updateBaseStatsHandler = updateBaseStatsHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<PlayableCharacter>> Fetch()
        {
            var playableCharacters = _fetchHandler.Handle(new Fetch());

            return Ok(playableCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<PlayableCharacter> Find(string name)
        {
            var playableCharacter = _findHandler.Handle(new Find(name));

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
