using System;
using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Application.Write.Characters.NonPlayable
{
    public record Create(string Name) : ICommand, ICharacterBuilder
    {
        #region Public Interface

        public NonPlayableCharacter Build()
        {
            return new(this);
        }

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.None;
        }

        public CombatStats GetCombatStats()
        {
            throw new NotSupportedException();
        }

        public EnemyCombatStats GetEnemyCombatStats()
        {
            throw new NotSupportedException();
        }

        public Id GetId()
        {
            return default;
        }

        public Name GetName()
        {
            return Name;
        }

        #endregion

        #region Static Interface

        public static NonPlayableCharacter Build(Create builder)
        {
            return builder.Build();
        }

        #endregion

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
    }
}
