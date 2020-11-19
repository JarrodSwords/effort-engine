using System;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class Level : ValueObject<Level>
    {
        #region Core

        public Level(byte value, ushort required, Stats combatStatReward)
        {
            Value = value;
            Required = CreateXp(required);
            CombatStatReward = combatStatReward;
        }

        #endregion

        #region Public Interface

        public Stats CombatStatReward { get; }
        public Xp Required { get; }
        public byte Value { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Level other) => throw new NotImplementedException();
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
