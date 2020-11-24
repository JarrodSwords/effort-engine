using System;
using Effort.Domain;
using static Effort.Domain.Name;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment : Entity
    {
        public static Equipment DefaultAccessory = new NullEquipment(EquipmentSlot.Accessory);
        public static Equipment DefaultArmor = new NullEquipment(EquipmentSlot.Armor);
        public static Equipment DefaultWeapon = new NullEquipment(EquipmentSlot.Weapon, "Unarmed");

        #region Creation

        private Equipment(
            Guid id,
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Status status
        ) : base(id)
        {
            Name = CreateName(name);
            EquipmentType = equipmentType;
            EquipmentSlot = equipmentSlot;
            Stats = CreateStats(EquipmentType);
            CharacterTypes = characterTypes;
            Status = status ?? new Status();
        }

        public static Equipment CreateEquipment(
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Status status = default,
            Guid id = default
        ) =>
            new Equipment(id, equipmentType, equipmentSlot, characterTypes, name, status);

        #endregion

        #region Public Interface

        public CharacterTypes CharacterTypes { get; }
        public EquipmentSlot EquipmentSlot { get; }
        public EquipmentType EquipmentType { get; }
        public Name Name { get; }
        public Stats Stats { get; }
        public Status Status { get; }

        public bool IsCompatible(CharacterTypes characterType) => CharacterTypes.Contains(characterType);

        public override string ToString() => Name.ToString();

        #endregion
    }
}
