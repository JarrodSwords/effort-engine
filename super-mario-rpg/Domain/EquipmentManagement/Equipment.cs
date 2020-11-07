using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Equipment : ValueObject<Equipment>
    {
        #region Core

        public Equipment(Slot slot, string name)
        {
            Slot = slot;
            Name = name;
        }

        private Equipment(Equipment equipment) : this(
            equipment.Slot,
            equipment.Name
        )
        {
        }

        #endregion

        #region Public Interface

        public Slot Slot { get; }
        public string Name { get; }

        public Equipment Clone() => new Equipment(this);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) =>
            Slot == other.Slot && Name == other.Name;

        protected override int GetHashCodeExplicit() => Slot.GetHashCode() + Name.GetHashCode();

        #endregion
    }
}
