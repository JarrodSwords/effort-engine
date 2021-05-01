using Effort.Domain;
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
            Id id,
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Buffs buffs
        ) : base(id)
        {
            Name = new(name);
            EquipmentType = equipmentType;
            EquipmentSlot = equipmentSlot;
            Stats = CreateStats(EquipmentType);
            CharacterTypes = characterTypes;
            Buffs = buffs;
        }

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

        public Status GetStatus() => new(buffs: Buffs);

        #endregion

        #region Static Interface

        public static Equipment CreateEquipment(EquipmentSlot equipmentSlot) =>
            new(new Id(), EquipmentType.None, equipmentSlot, CharacterTypes.Playable, null, Buffs.None);

        public static Equipment CreateEquipment(
            EquipmentType equipmentType,
            EquipmentSlot equipmentSlot,
            CharacterTypes characterTypes,
            string name,
            Buffs buffs = default,
            Id id = default
        ) =>
            new(id, equipmentType, equipmentSlot, characterTypes, name, buffs);

        #endregion
    }
}
