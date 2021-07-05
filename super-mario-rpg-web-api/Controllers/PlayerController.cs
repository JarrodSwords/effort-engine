using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write.Players;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IQueryHandler<FindPlayer, Player> _findPlayerHandler;
        private readonly ICommandHandler<Register> _registerHandler;

        #region Creation

        public PlayerController(
            IQueryHandler<FindPlayer, Player> findPlayerHandler,
            ICommandHandler<Register> registerHandler
        )
        {
            _findPlayerHandler = findPlayerHandler;
            _registerHandler = registerHandler;
        }

        #endregion

        #region Public Interface

        [Route("{userName}")]
        [HttpGet]
        public ActionResult<Player> Find(string userName)
        {
            var player = _findPlayerHandler.Handle(new FindPlayer(userName));

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

        public record RegisterPlayerArgs(
            string EmailAddress,
            string Password,
            string UserName
        );
    }
}
