using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateNonPlayerCharacter(string Name) : ICommand, Character.IBuilder
    {
        #region Public Interface

        public NonPlayerCharacter Build()
        {
            return new(this);
        }

        public static NonPlayerCharacter Build(CreateNonPlayerCharacter builder)
        {
            return builder.Build();
        }

        #endregion

        #region IBuilder Implementation

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
                UnitOfWork.NonPlayerCharacters.Create(command.Build());

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
