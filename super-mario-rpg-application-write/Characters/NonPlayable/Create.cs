using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write.Characters.NonPlayable
{
    public record Create(string Name) : ICommand, Character.IBuilder
    {
        #region Public Interface

        public NonPlayableCharacter Build()
        {
            return new(this);
        }

        public static NonPlayableCharacter Build(Create builder)
        {
            return builder.Build();
        }

        #endregion

        #region IBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.None;
        }

        public Enemy.CombatStats GetEnemyCombatStats()
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

        public PlayableCharacter.CombatStats GetPlayableCharacterCombatStats()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Nested Types

        [Log]
        internal class Handler : Handler<Create>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(Create command)
            {
                UnitOfWork.NonPlayerCharacters.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
