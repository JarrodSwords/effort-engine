using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/enemies")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly ICommandHandler<CreateEnemy> _createEnemyHandler;
        private readonly IQueryHandler<FetchEnemies, IEnumerable<Enemy>> _fetchEnemiesHandler;

        #region Creation

        public EnemyController(
            ICommandHandler<CreateEnemy> createEnemyHandler,
            IQueryHandler<FetchEnemies, IEnumerable<Enemy>> fetchEnemiesHandler
        )
        {
            _createEnemyHandler = createEnemyHandler;
            _fetchEnemiesHandler = fetchEnemiesHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateEnemy([FromBody] CreateEnemyArgs args)
        {
            var (name, hitPoints, flowerPoints, speed, attack, defense, magicAttack, magicDefense, evade, magicEvade) =
                args;

            var command = new CreateEnemy(
                name,
                hitPoints,
                flowerPoints,
                attack,
                defense,
                magicAttack,
                magicDefense,
                speed,
                evade,
                magicEvade
            );

            _createEnemyHandler.Handle(command);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enemy>> FetchEnemies()
        {
            var enemies = _fetchEnemiesHandler.Handle(new FetchEnemies());
            return Ok(enemies);
        }

        #endregion
    }
}
