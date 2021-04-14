using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.Enemies;
using SuperMarioRpg.Application.Write.Enemies;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/enemies")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly ICommandHandler<Create> _createHandler;
        private readonly IQueryHandler<Fetch, IEnumerable<Enemy>> _fetchHandler;
        private readonly IQueryHandler<Find, Enemy> _findHandler;

        #region Creation

        public EnemyController(
            ICommandHandler<Create> createHandler,
            IQueryHandler<Fetch, IEnumerable<Enemy>> fetchHandler,
            IQueryHandler<Find, Enemy> findHandler
        )
        {
            _createHandler = createHandler;
            _fetchHandler = fetchHandler;
            _findHandler = findHandler;
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
            var enemies = _fetchHandler.Handle(new Fetch());

            return Ok(enemies);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Enemy> Find(string name)
        {
            var enemy = _findHandler.Handle(new Find(name));

            return Ok(enemy);
        }

        #endregion
    }
}
