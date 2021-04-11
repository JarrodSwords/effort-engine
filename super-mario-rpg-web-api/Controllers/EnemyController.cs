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
        private readonly IQueryHandler<FindEnemy, Enemy> _findEnemyHandler;

        #region Creation

        public EnemyController(
            ICommandHandler<CreateEnemy> createEnemyHandler,
            IQueryHandler<FetchEnemies, IEnumerable<Enemy>> fetchEnemiesHandler,
            IQueryHandler<FindEnemy, Enemy> findEnemyHandler
        )
        {
            _createEnemyHandler = createEnemyHandler;
            _fetchEnemiesHandler = fetchEnemiesHandler;
            _findEnemyHandler = findEnemyHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateEnemy([FromBody] CreateEnemyArgs args)
        {
            var (name, hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade, magicEvade) =
                args;

            var command = new CreateEnemy(
                name,
                hitPoints,
                flowerPoints,
                speed,
                attack,
                magicAttack,
                defense,
                magicDefense,
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

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Enemy> FindEnemy(string name)
        {
            var enemy = _findEnemyHandler.Handle(new FindEnemy(name));

            return Ok(enemy);
        }

        #endregion
    }
}
