using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class SimpleLoadout : ValueObject<SimpleLoadout>, ILoadout
    {
        #region Core

        public SimpleLoadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
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

        #endregion

        #region ILoadout

        public ILoadout Equip(Equipment equipment)
        {
            return equipment.Slot switch
            {
                Slot.Accessory => new SimpleLoadout(equipment, Armor, Weapon),
                Slot.Armor => new SimpleLoadout(Accessory, equipment, Weapon),
                Slot.Weapon => new SimpleLoadout(Accessory, Armor, equipment),
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

        public Stats GetStats() => Accessory.Stats + Armor.Stats + Weapon.Stats;

        public ILoadout Unequip(Id id)
        {
            if (Accessory.Id == id)
                return new SimpleLoadout(armor: Armor, weapon: Weapon);

            if (Armor.Id == id)
                return new SimpleLoadout(Accessory, weapon: Weapon);

            if (Weapon.Id == id)
                return new SimpleLoadout(Accessory, Armor);

            return this;
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(SimpleLoadout other) => throw new NotImplementedException();

        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
