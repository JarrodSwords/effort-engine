﻿using Effort.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Write;

namespace SuperMarioRpg.WebApi.Controllers
{
    [Route("api/non-player-characters")]
    [ApiController]
    public class NonPlayerCharacterController : ControllerBase
    {
        private readonly ICommandHandler<CreateNonPlayerCharacter> _createCharacterHandler;

        #region Creation

        public NonPlayerCharacterController(ICommandHandler<CreateNonPlayerCharacter> createCharacterHandler)
        {
            _createCharacterHandler = createCharacterHandler;
        }

        #endregion

        #region Public Interface

        [HttpPost]
        public IActionResult CreateCharacter([FromBody] CreateNonPlayerCharacterArgs args)
        {
            _createCharacterHandler.Handle(new CreateNonPlayerCharacter(args.Name));

            return Ok();
        }

        #endregion
    }
}
