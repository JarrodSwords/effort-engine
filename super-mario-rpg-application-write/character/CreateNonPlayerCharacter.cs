using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateNonPlayerCharacter(string Name) : ICommand
    {
        #region Nested Types

        [Log]
        internal class Handler : Handler<CreateNonPlayerCharacter>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(CreateNonPlayerCharacter command)
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
        private CreateNonPlayerCharacter _createNonPlayerCharacter;

        #region Public Interface

        public Builder From(CreateNonPlayerCharacter command)
        {
            _createNonPlayerCharacter = command;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            throw new NotImplementedException();
        }

        public Guid GetId()
        {
            return Guid.Empty;
        }

        public string GetName()
        {
            return _createNonPlayerCharacter.Name;
        }

        #endregion
    }
}
