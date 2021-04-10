using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/enemies")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly ICommandHandler<CreateEnemy> _createEnemyHandler;

        #region Creation

        public EnemyController(ICommandHandler<CreateEnemy> createEnemyHandler)
        {
            _createEnemyHandler = createEnemyHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateEnemy([FromBody] CreateEnemyArgs args)
        {
            var (name, hitPoints, attack, defense, magicAttack, magicDefense, speed, evade, magicEvade) = args;

            var command = new CreateEnemy(
                name,
                hitPoints,
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

        #endregion
    }
}
