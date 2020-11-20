using System;
using Effort.Domain;
using static Effort.Domain.Name;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment : Entity
    {
        public static Equipment DefaultAccessory = new NullEquipment(Slot.Accessory);
        public static Equipment DefaultArmor = new NullEquipment(Slot.Armor);
        public static Equipment DefaultWeapon = new NullEquipment(Slot.Weapon, "Unarmed");

        #region Creation

        public Equipment(
            string name,
            EquipmentType equipmentType,
            Slot slot,
            CharacterTypes compatibleCharacterTypes,
            Guid id = default
        ) : base(id)
        {
            Name = CreateName(name);
            EquipmentType = equipmentType;
            Slot = slot;
            Stats = CreateStats(EquipmentType);
            CompatibleCharacterTypes = compatibleCharacterTypes;
        }

        private Equipment(Equipment equipment) : this(
            equipment.Name.Value,
            equipment.EquipmentType,
            equipment.Slot,
            equipment.CompatibleCharacterTypes,
            equipment.Id.Value
        )
        {
        }

        #endregion

        #region Public Interface

        public CharacterTypes CompatibleCharacterTypes { get; }
        public EquipmentType EquipmentType { get; }
        public Name Name { get; }
        public Slot Slot { get; }
        public Stats Stats { get; }

        public Equipment Clone() => new Equipment(this);

        public bool IsCompatible(CharacterTypes characterType) => (characterType & CompatibleCharacterTypes) > 0;

        public override string ToString() => Name.ToString();

        #endregion
    }
}
