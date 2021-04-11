using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;
using CombatStats = SuperMarioRpg.Domain.CombatStats;

namespace SuperMarioRpg.Application.Write
{
    public record CreateNonPlayerCharacter(string Name) : ICommand
    {
        #region Nested Types

        internal class Builder : ICharacterBuilder
        {
            private CreateNonPlayerCharacter _command;

            #region Public Interface

            public NonPlayerCharacter Build()
            {
                return new(this);
            }

            public Builder From(CreateNonPlayerCharacter command)
            {
                _command = command;
                return this;
            }

            #endregion

            #region ICharacterBuilder Implementation

            public CharacterTypes GetCharacterTypes()
            {
                return CharacterTypes.NonPlayerCharacter;
            }

            public CombatStats GetCombatStats()
            {
                throw new NotSupportedException();
            }

            public Guid GetId()
            {
                return Guid.Empty;
            }

            public string GetName()
            {
                return _command.Name;
            }

            #endregion
        }

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

                UnitOfWork.NonPlayerCharacterRepository.Create(character);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
