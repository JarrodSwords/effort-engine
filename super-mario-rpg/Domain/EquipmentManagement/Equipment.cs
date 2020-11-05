using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Equipment : ValueObject<Equipment>
    {
        #region Core

        public Equipment(EquipmentType equipmentType, string name)
        {
            EquipmentType = equipmentType;
            Name = name;
        }

        private Equipment(Equipment equipment) : this(
            equipment.EquipmentType,
            equipment.Name
        )
        {
        }

        #endregion

        #region Public Interface

        public EquipmentType EquipmentType { get; }
        public string Name { get; }

        public Equipment Clone() => new Equipment(this);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) =>
            EquipmentType == other.EquipmentType && Name == other.Name;

        protected override int GetHashCodeExplicit() => EquipmentType.GetHashCode() + Name.GetHashCode();

        #endregion
    }
}
