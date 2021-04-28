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
        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.None;
        public CombatStats GetCombatStats() => throw new NotSupportedException();
        public EnemyCombatStats GetEnemyCombatStats() => throw new NotSupportedException();
        public Id GetId() => default;
        public Name GetName() => Name;

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
                UnitOfWork.NonPlayerCharacters.Create(new NonPlayableCharacter(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
