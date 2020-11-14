using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Stats : ValueObject<Stats>
    {
        #region Core

        public Stats(ushort attack)
        {
            Attack = attack;
        }

        #endregion

        #region Public Interface

        public ushort Attack { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Stats other) => Attack == other.Attack;

        protected override int GetHashCodeExplicit() => Attack.GetHashCode();

        #endregion
    }
}
