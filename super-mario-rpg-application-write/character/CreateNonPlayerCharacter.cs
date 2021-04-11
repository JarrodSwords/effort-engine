using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateNonPlayerCharacter(string Name) : ICommand, ICharacterBuilder
    {
        #region Public Interface

        public NonPlayerCharacter Build()
        {
            return new(this);
        }

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.NonPlayerCharacter;
        }

        public Enemy.CombatStats GetCombatStats()
        {
            throw new NotSupportedException();
        }

        public Guid GetId()
        {
            return default;
        }

        public string GetName()
        {
            return Name;
        }

        #endregion

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
                var nonPlayerCharacter = command.Build();

                UnitOfWork.NonPlayerCharacterRepository.Create(nonPlayerCharacter);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
