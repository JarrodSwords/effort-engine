using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain;

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
                var builder = new Builder().From(command);
                var character = new NonPlayerCharacter(builder);

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

    internal class Builder : ICharacterBuilder
    {
        private CreateCharacter _createCharacter;

        #region Public Interface

        public Builder From(CreateCharacter command)
        {
            _createCharacter = command;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Guid GetId()
        {
            return Guid.Empty;
        }

        public string GetName()
        {
            return _createCharacter.Name;
        }

        #endregion
    }
}
