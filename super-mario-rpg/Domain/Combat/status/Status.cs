using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Status : ValueObject
    {
        public static Status Default = new Status();

        #region Creation

        public Status(
            Ailments ailmentImmunities = default,
            Buffs buffs = default,
            Elements elementalImmunities = default,
            Elements elementalResistances = default
        )
        {
            AilmentImmunities = ailmentImmunities;
            Buffs = buffs;
            ElementalImmunities = elementalImmunities;
            ElementalResistances = elementalResistances;
        }

        #endregion

        #region Public Interface

        public Ailments AilmentImmunities { get; }
        public Buffs Buffs { get; }
        public Elements ElementalImmunities { get; }
        public Elements ElementalResistances { get; }

        public static Status Aggregate(params IStatusProvider[] statusProviders)
        {
            return statusProviders.Aggregate(Default, (current, statusProvider) => current + statusProvider.GetStatus());
        }

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AilmentImmunities;
            yield return Buffs;
            yield return ElementalImmunities;
            yield return ElementalResistances;
        }

        public static Status operator +(Status left, Status right) =>
            new Status(
                left.AilmentImmunities | right.AilmentImmunities,
                left.Buffs | right.Buffs,
                left.ElementalImmunities | right.ElementalImmunities,
                left.ElementalResistances | right.ElementalResistances
            );

        #endregion
    }
}
