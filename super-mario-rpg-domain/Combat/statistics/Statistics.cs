using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Statistics : ValueObject
    {
        #region Creation

        public Statistics(
            Attack attack,
            Defense defense,
            MagicAttack magicAttack,
            MagicDefense magicDefense,
            Speed speed
        )
        {
            Attack = attack;
            Defense = defense;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
            Speed = speed;
        }

        #endregion

        #region Public Interface

        public Attack Attack { get; }
        public Defense Defense { get; }
        public MagicAttack MagicAttack { get; }
        public MagicDefense MagicDefense { get; }
        public Speed Speed { get; }

        #endregion

        #region Equality

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Attack;
            yield return Defense;
            yield return MagicAttack;
            yield return MagicDefense;
            yield return Speed;
        }

        #endregion
    }
}
