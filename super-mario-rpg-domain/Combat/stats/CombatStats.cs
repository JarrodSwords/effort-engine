using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class CombatStats : ValueObject
    {
        #region Creation

        public CombatStats(ICombatStatsBuilder builder)
        {
            Attack = builder.GetAttack();
            Defense = builder.GetDefense();
            HitPoints = builder.GetHitPoints();
            MagicAttack = builder.GetMagicAttack();
            MagicDefense = builder.GetMagicDefense();
            Speed = builder.GetSpeed();
        }

        #endregion

        #region Public Interface

        public short Attack { get; }
        public short Defense { get; }
        public ushort HitPoints { get; }
        public short MagicAttack { get; }
        public short MagicDefense { get; }
        public short Speed { get; }

        #endregion

        #region Equality

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Attack;
            yield return Defense;
            yield return HitPoints;
            yield return MagicAttack;
            yield return MagicDefense;
            yield return Speed;
        }

        #endregion
    }
}
