using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/non-player-characters")]
    [ApiController]
    public class NonPlayerCharacterController : ControllerBase
    {
        private readonly ICommandHandler<CreateNonPlayerCharacter> _createCharacterHandler;

        private readonly IQueryHandler<FetchNonPlayerCharacters, IEnumerable<NonPlayerCharacter>>
            _fetchNonPlayerCharactersHandler;

        private readonly IQueryHandler<FindNonPlayerCharacter, NonPlayerCharacter> _findNonPlayerCharacterHandler;

        #region Creation

        public NonPlayerCharacterController(
            ICommandHandler<CreateNonPlayerCharacter> createCharacterHandler,
            IQueryHandler<FetchNonPlayerCharacters, IEnumerable<NonPlayerCharacter>> fetchNonPlayerCharactersHandler,
            IQueryHandler<FindNonPlayerCharacter, NonPlayerCharacter> findNonPlayerCharacterHandler
        )
        {
            _createCharacterHandler = createCharacterHandler;
            _fetchNonPlayerCharactersHandler = fetchNonPlayerCharactersHandler;
            _findNonPlayerCharacterHandler = findNonPlayerCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateNonPlayerCharacter([FromBody] CreateNonPlayerCharacterArgs args)
        {
            _createCharacterHandler.Handle(new CreateNonPlayerCharacter(args.Name));

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<NonPlayerCharacter>> FetchNonPlayerCharacters()
        {
            var nonPlayerCharacters = _fetchNonPlayerCharactersHandler.Handle(new FetchNonPlayerCharacters());

            return Ok(nonPlayerCharacters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<NonPlayerCharacter> FindNonPlayerCharacter(string name)
        {
            var nonPlayerCharacters = _findNonPlayerCharacterHandler.Handle(new FindNonPlayerCharacter(name));

            return Ok(nonPlayerCharacters);
        }

        #endregion
    }
}
