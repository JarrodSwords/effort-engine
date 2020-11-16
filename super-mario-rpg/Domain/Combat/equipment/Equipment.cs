using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment : Entity
    {
        #region Core

        public static Equipment NullAccessory = new NullEquipment(Slot.Accessory);
        public static Equipment NullArmor = new NullEquipment(Slot.Armor);
        public static Equipment NullWeapon = new NullEquipment(Slot.Weapon, "Unarmed");

        public Equipment(
            string name,
            EquipmentType equipmentType,
            Slot slot,
            Characters compatibleCharacters,
            Guid id = new Guid()
        ) : base(id)
        {
            Name = Name.Create(name);
            EquipmentType = equipmentType;
            Slot = slot;
            Stats = StatFactory.Instance.Create(EquipmentType);
            CompatibleCharacters = compatibleCharacters;
        }

        private Equipment(Equipment equipment) : this(
            equipment.Name.Value,
            equipment.EquipmentType,
            equipment.Slot,
            equipment.CompatibleCharacters,
            equipment.Id.Value
        )
        {
        }

        #endregion

        #region Public Interface

        public Characters CompatibleCharacters { get; }
        public EquipmentType EquipmentType { get; }
        public Name Name { get; }
        public Slot Slot { get; }
        public Stats Stats { get; }

        public Equipment Clone() => new Equipment(this);

        public bool IsCompatible(Characters character) => (character & CompatibleCharacters) > 0;

        public override string ToString() => Name.ToString();

        #endregion
    }
}
