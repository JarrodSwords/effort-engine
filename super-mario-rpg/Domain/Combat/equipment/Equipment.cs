using System;
using Effort.Domain;
using static Effort.Domain.Name;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public class Equipment : Entity, IStatusProvider
    {
        public static Equipment DefaultAccessory = CreateEquipment(EquipmentSlot.Accessory);
        public static Equipment DefaultArmor = CreateEquipment(EquipmentSlot.Armor);
        public static Equipment DefaultWeapon = CreateEquipment(EquipmentSlot.Weapon);

        #region Creation

        private Equipment(
            Guid id,
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Buffs buffs
        ) : base(id)
        {
            Name = CreateName(name);
            EquipmentType = equipmentType;
            EquipmentSlot = equipmentSlot;
            Stats = CreateStats(EquipmentType);
            CharacterTypes = characterTypes;
            Buffs = buffs;
        }

        public static Equipment CreateEquipment(EquipmentSlot equipmentSlot) =>
            new Equipment(Guid.Empty, EquipmentType.None, equipmentSlot, CharacterTypes.All, null, Buffs.None);

        public static Equipment CreateEquipment(
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Buffs buffs = default,
            Guid id = default
        ) =>
            new Equipment(id, equipmentType, equipmentSlot, characterTypes, name, buffs);

        #endregion

        #region Public Interface

        public Buffs Buffs { get; }
        public CharacterTypes CharacterTypes { get; }
        public EquipmentSlot EquipmentSlot { get; }
        public EquipmentType EquipmentType { get; }
        public Name Name { get; }
        public Stats Stats { get; }

        public bool IsCompatible(CharacterTypes characterType) => CharacterTypes.Contains(characterType);

        public override string ToString() => Name.ToString();

        #endregion

        #region IStatusProvider Implementation

        public Status GetStatus() => new Status(buffs: Buffs);

        #endregion
    }
}
