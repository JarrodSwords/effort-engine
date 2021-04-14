using System.Collections.Generic;
using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Read.Characters;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IQueryHandler<Fetch, IEnumerable<Character>> _fetchHandler;
        private readonly IQueryHandler<Find, Character> _findHandler;

        #region Creation

        public CharacterController(
            IQueryHandler<Fetch, IEnumerable<Character>> fetchHandler,
            IQueryHandler<Find, Character> findHandler
        )
        {
            _fetchHandler = fetchHandler;
            _findHandler = findHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<Character>> Fetch()
        {
            var characters = _fetchHandler.Handle(new Fetch());

            return Ok(characters);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<Character> Find(string name)
        {
            var character = _findHandler.Handle(new Find(name));

            return Ok(character);
        }

        #endregion
    }
}
