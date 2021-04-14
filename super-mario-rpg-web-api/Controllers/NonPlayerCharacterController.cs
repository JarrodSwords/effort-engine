using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.NonPlayerCharacters;
using SuperMarioRpg.Application.Write.NonPlayerCharacters;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/non-player-characters")]
    [ApiController]
    public class NonPlayerCharacterController : ControllerBase
    {
        private readonly ICommandHandler<Create> _createHandler;
        private readonly IQueryHandler<Fetch, IEnumerable<NonPlayerCharacter>> _fetchHandler;
        private readonly IQueryHandler<Find, NonPlayerCharacter> _findHandler;

        #region Creation

        public NonPlayerCharacterController(
            ICommandHandler<Create> createHandler,
            IQueryHandler<Fetch, IEnumerable<NonPlayerCharacter>> fetchHandler,
            IQueryHandler<Find, NonPlayerCharacter> findHandler
        )
        {
            _createHandler = createHandler;
            _fetchHandler = fetchHandler;
            _findHandler = findHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult Create([FromBody] CreateNonPlayerCharacterArgs args)
        {
            _createHandler.Handle(new Create(args.Name));

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<NonPlayerCharacter>> Fetch()
        {
            var nonPlayerCharacters = _fetchHandler.Handle(new Fetch());

            return Ok(nonPlayerCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<NonPlayerCharacter> Find(string name)
        {
            var nonPlayerCharacters = _findHandler.Handle(new Find(name));

            return Ok(nonPlayerCharacters);
        }

        #endregion
    }
}
