using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.Characters.NonPlayable;
using SuperMarioRpg.Application.Write.Characters.NonPlayable;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/non-player-characters")]
    [ApiController]
    public class NonPlayerCharacterController : ControllerBase
    {
        private readonly ICommandHandler<Create> _createHandler;
        private readonly IQueryHandler<Fetch, IEnumerable<NonPlayableCharacter>> _fetchHandler;
        private readonly IQueryHandler<Find, NonPlayableCharacter> _findHandler;

        #region Creation

        public NonPlayerCharacterController(
            ICommandHandler<Create> createHandler,
            IQueryHandler<Fetch, IEnumerable<NonPlayableCharacter>> fetchHandler,
            IQueryHandler<Find, NonPlayableCharacter> findHandler
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
        public ActionResult<IEnumerable<NonPlayableCharacter>> Fetch()
        {
            var nonPlayerCharacters = _fetchHandler.Handle(new Fetch());

            return Ok(nonPlayerCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<NonPlayableCharacter> Find(string name)
        {
            var nonPlayerCharacters = _findHandler.Handle(new Find(name));

            return Ok(nonPlayerCharacters);
        }

        #endregion
    }
}
