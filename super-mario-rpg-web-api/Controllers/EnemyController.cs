using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write.Characters.Enemies;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/enemies")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly ICommandHandler<Create> _createHandler;
        private readonly IQueryHandler<FetchEnemies, IEnumerable<Enemy>> _fetchEnemiesHandler;
        private readonly IQueryHandler<FindEnemy, Enemy> _findEnemyHandler;

        #region Creation

        public EnemyController(
            ICommandHandler<Create> createHandler,
            IQueryHandler<FetchEnemies, IEnumerable<Enemy>> fetchEnemiesHandler,
            IQueryHandler<FindEnemy, Enemy> findEnemyHandler
        )
        {
            _createHandler = createHandler;
            _fetchEnemiesHandler = fetchEnemiesHandler;
            _findEnemyHandler = findEnemyHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult Create([FromBody] CreateEnemyArgs args)
        {
            var (name, hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade, magicEvade) =
                args;

            var command = new Create(
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

            _createHandler.Handle(command);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enemy>> Fetch()
        {
            var enemies = _fetchEnemiesHandler.Handle(new FetchEnemies());

            return Ok(enemies);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Enemy> Find(string name)
        {
            var enemy = _findEnemyHandler.Handle(new FindEnemy(name));

            return Ok(enemy);
        }

        #endregion

        public record CreateEnemyArgs(
            string Name,
            short HitPoints,
            byte FlowerPoints,
            short Speed,
            short Attack,
            short MagicAttack,
            short Defense,
            short MagicDefense,
            decimal Evade,
            decimal MagicEvade
        );
    }
}
