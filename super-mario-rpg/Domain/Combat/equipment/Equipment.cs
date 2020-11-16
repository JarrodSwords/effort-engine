using System;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.StatFactory;

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
            CharacterTypes compatibleCharacterTypes,
            Guid id = new Guid()
        ) : base(id)
        {
            Name = Name.Create(name);
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
