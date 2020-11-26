using System;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Status;

namespace SuperMarioRpg.Domain.Combat
{
    public record Loadout : IStatusProvider
    {
        #region Creation

        public Loadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
        {
            Accessory = accessory ?? Equipment.DefaultAccessory;
            Armor = armor ?? Equipment.DefaultArmor;
            Weapon = weapon ?? Equipment.DefaultWeapon;
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; }
        public Equipment Armor { get; }
        public Equipment Weapon { get; }

        public Loadout Equip(Equipment equipment)
        {
            return equipment.EquipmentSlot switch
            {
                EquipmentSlot.Accessory => new Loadout(equipment, Armor, Weapon),
                EquipmentSlot.Armor => new Loadout(Accessory, equipment, Weapon),
                EquipmentSlot.Weapon => new Loadout(Accessory, Armor, equipment),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Equipment GetEquipment(EquipmentSlot equipmentSlot)
        {
            return equipmentSlot switch
            {
                EquipmentSlot.Accessory => Accessory,
                EquipmentSlot.Armor => Armor,
                EquipmentSlot.Weapon => Weapon,
                _ => throw new ArgumentOutOfRangeException(nameof(equipmentSlot), equipmentSlot, null)
            };
        }

        public Stats GetStats() => Stats.Aggregate(Accessory.Stats, Armor.Stats, Weapon.Stats);

        public bool IsEquipped(Equipment equipment) => equipment == GetEquipment(equipment.EquipmentSlot);

        public Loadout Unequip(Id id)
        {
            if (Accessory.Id == id)
                return new Loadout(armor: Armor, weapon: Weapon);

            if (Armor.Id == id)
                return new Loadout(Accessory, weapon: Weapon);

            if (Weapon.Id == id)
                return new Loadout(Accessory, Armor);

            return this;
        }

        #endregion

        #region IStatusProvider Implementation

        public Status GetStatus() => Aggregate(Accessory, Armor, Weapon);

        #endregion
    }
}
