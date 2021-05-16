using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public class Statistics : ValueObject
    {
        #region Creation

        public Statistics(IStatisticsBuilder builder)
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

        public Attack Attack { get; }
        public Defense Defense { get; }
        public HitPoints HitPoints { get; }
        public MagicAttack MagicAttack { get; }
        public MagicDefense MagicDefense { get; }
        public Speed Speed { get; }

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
