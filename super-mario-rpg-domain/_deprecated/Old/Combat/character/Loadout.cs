using System;
using static SuperMarioRpg.Domain.Old.Combat.Equipment;
using static SuperMarioRpg.Domain.Old.Combat.Status;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public record Loadout : IStatusProvider
    {
        #region Creation

        public Loadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
        {
            Accessory = accessory ?? DefaultAccessory;
            Armor = armor ?? DefaultArmor;
            Weapon = weapon ?? DefaultWeapon;
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; init; }
        public Equipment Armor { get; init; }
        public Equipment Weapon { get; init; }

        public Loadout Equip(Equipment equipment)
        {
            return equipment.EquipmentSlot switch
            {
                EquipmentSlot.Accessory => this with { Accessory = equipment },
                EquipmentSlot.Armor => this with { Armor = equipment },
                EquipmentSlot.Weapon => this with { Weapon = equipment },
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

        public Loadout Unequip(Equipment equipment)
        {
            if (Accessory == equipment)
                return this with { Accessory = DefaultAccessory };

            if (Armor == equipment)
                return this with { Armor = DefaultArmor };

            if (Weapon == equipment)
                return this with { Weapon = DefaultWeapon };

            return this;
        }

        #endregion

        #region IStatusProvider Implementation

        public Status GetStatus() => Aggregate(Accessory, Armor, Weapon);

        #endregion
    }
}
