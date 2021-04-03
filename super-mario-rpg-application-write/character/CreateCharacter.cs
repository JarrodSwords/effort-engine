﻿using Effort.Domain.Messages;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateCharacter(string Name) : ICommand
    {
        #region Nested Types

        [Log]
        internal class Handler : Handler<CreateCharacter>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(CreateCharacter command)
            {
                var builder = new NewCharacterBuilder().For(CharacterTypes.Mario);
                new Director().Configure(builder);

                var character = builder.Build();

                UnitOfWork.CharacterRepository.Create(character);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }

    public record CreateCharacterDto(
        string Name,
        CombatStatsDto CombatStats
    );
}
