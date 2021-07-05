using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write.Characters.NonPlayable;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/non-playable-characters")]
    [ApiController]
    public class NonPlayableCharacterController : ControllerBase
    {
        private readonly ICommandHandler<Create> _createHandler;

        private readonly IQueryHandler<FetchNonPlayableCharacters, IEnumerable<NonPlayableCharacter>>
            _fetchNonPlayableCharacterHandler;

        private readonly IQueryHandler<FindNonPlayableCharacter, NonPlayableCharacter> _findNonPlayableCharacterHandler;

        #region Creation

        public NonPlayableCharacterController(
            ICommandHandler<Create> createHandler,
            IQueryHandler<FetchNonPlayableCharacters, IEnumerable<NonPlayableCharacter>>
                fetchNonPlayableCharacterHandler,
            IQueryHandler<FindNonPlayableCharacter, NonPlayableCharacter> findNonPlayableCharacterHandler
        )
        {
            _createHandler = createHandler;
            _fetchNonPlayableCharacterHandler = fetchNonPlayableCharacterHandler;
            _findNonPlayableCharacterHandler = findNonPlayableCharacterHandler;
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
            var nonPlayerCharacters = _fetchNonPlayableCharacterHandler.Handle(new FetchNonPlayableCharacters());

            return Ok(nonPlayerCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<NonPlayableCharacter> Find(string name)
        {
            var nonPlayerCharacters = _findNonPlayableCharacterHandler.Handle(new FindNonPlayableCharacter(name));

            return Ok(nonPlayerCharacters);
        }

        #endregion

        public record CreateNonPlayerCharacterArgs(string Name);
    }
}
