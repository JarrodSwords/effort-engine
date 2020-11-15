using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Equipment : ValueObject<Equipment>
    {
        #region Core

        public Equipment(Slot slot, string name, Stats stats)
        {
            Slot = slot;
            Stats = stats;
            Name = Name.Create(name);
        }

        private Equipment(Equipment equipment) : this(
            equipment.Slot,
            equipment.Name.Value,
            equipment.Stats
        )
        {
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Slot Slot { get; }
        public Stats Stats { get; }

        public Equipment Clone() => new Equipment(this);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) => Slot == other.Slot && Name == other.Name;
        protected override int GetHashCodeExplicit() => Slot.GetHashCode() + Name.GetHashCode();

        #endregion
    }
}
