using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Equipment : ValueObject<Equipment>
    {
        #region Core

        public Equipment(Slot slot, string name)
        {
            Slot = slot;
            Name = Name.Create(name);
        }

        private Equipment(Equipment equipment) : this(
            equipment.Slot,
            equipment.Name.Value
        )
        {
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Slot Slot { get; }

        public Equipment Clone() => new Equipment(this);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) => Slot == other.Slot && Name == other.Name;

        protected override int GetHashCodeExplicit() => Slot.GetHashCode() + Name.GetHashCode();

        #endregion
    }
}
