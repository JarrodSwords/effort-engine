using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Loadout : ValueObject<Loadout>
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
            return equipment.Slot switch
            {
                Slot.Accessory => new Loadout(equipment, Armor, Weapon),
                Slot.Armor => new Loadout(Accessory, equipment, Weapon),
                Slot.Weapon => new Loadout(Accessory, Armor, equipment),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Equipment GetEquipment(Slot slot)
        {
            return slot switch
            {
                Slot.Accessory => Accessory,
                Slot.Armor => Armor,
                Slot.Weapon => Weapon,
                _ => throw new ArgumentOutOfRangeException(nameof(slot), slot, null)
            };
        }

        public Stats GetStats() => Stats.Aggregate(Accessory.Stats, Armor.Stats, Weapon.Stats);
        public Status GetStatuses() => Status.Aggregate(Accessory.Status, Armor.Status, Weapon.Status);

        public bool IsEquipped(Equipment equipment) => equipment == GetEquipment(equipment.Slot);

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

        #region Equality, Operators

        protected override bool EqualsExplicit(Loadout other) => throw new NotImplementedException();

        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
