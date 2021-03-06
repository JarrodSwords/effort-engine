using System.Linq;

namespace SuperMarioRpg.Domain.Combat
{
    public record Status
    {
        public static Status Default = new();

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
            return statusProviders.Aggregate(
                Default,
                (current, statusProvider) => current + statusProvider.GetStatus()
            );
        }

        #endregion

        #region Equality, Operators

        public static Status operator +(Status left, Status right) =>
            new(
                left.AilmentImmunities | right.AilmentImmunities,
                left.Buffs | right.Buffs,
                left.ElementalImmunities | right.ElementalImmunities,
                left.ElementalResistances | right.ElementalResistances
            );

        #endregion
    }
}
