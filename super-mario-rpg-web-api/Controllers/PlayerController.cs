using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.Players;
using SuperMarioRpg.Application.Write.Players;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IQueryHandler<Find, Player> _findHandler;
        private readonly ICommandHandler<Register> _registerHandler;

        #region Creation

        public PlayerController(
            IQueryHandler<Find, Player> findHandler,
            ICommandHandler<Register> registerHandler
        )
        {
            _findHandler = findHandler;
            _registerHandler = registerHandler;
        }

        #endregion

        #region Public Interface

        [Route("{userName}")]
        [HttpGet]
        public ActionResult<Player> Find(string userName)
        {
            var player = _findHandler.Handle(new Find(userName));

            return Ok(player);
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterPlayerArgs args)
        {
            var (emailAddress, password, userName) = args;

            _registerHandler.Handle(new Register(emailAddress, password, userName));

            return Ok();
        }

        #endregion
    }
}
