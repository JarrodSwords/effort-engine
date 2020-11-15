using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        private Equipment _accessory;
        private Equipment _armor;
        private Equipment _weapon;

        public Loadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
        {
            _accessory = accessory;
            _armor = armor;
            _weapon = weapon;
        }

        public Loadout(IReadOnlyCollection<Equipment> equipment)
        {
            ValidateEquipment(equipment);
            _accessory = equipment.FirstOrDefault(x => x.Slot == Slot.Accessory);
            _armor = equipment.FirstOrDefault(x => x.Slot == Slot.Armor);
            _weapon = equipment.FirstOrDefault(x => x.Slot == Slot.Weapon);
        }

        #endregion

        #region Public Interface

        public Equipment Armor => _armor ??= new NullEquipment(Slot.Armor);
        public Equipment Weapon => _weapon ??= new NullEquipment(Slot.Weapon);
        public Equipment Accessory => _accessory ??= new NullEquipment(Slot.Accessory);

        public bool CheckCompatibility(Characters character) =>
            (Accessory.CompatibleCharacters
           & Armor.CompatibleCharacters
           & Weapon.CompatibleCharacters
           & character)
          > 0;

        #endregion

        #region Private Interface

        private void ValidateEquipment(IReadOnlyCollection<Equipment> equipment)
        {
            var equipmentBySlot = from e in equipment
                                  group e by e.Slot
                                  into g
                                  select new
                                  {
                                      Equipment = g.Key,
                                      Count = g.Count()
                                  };

            if (equipmentBySlot.Any(x => x.Count > 1))
                throw new ArgumentException(
                    $"Invalid {nameof(Loadout)}. Cannot have more than one item per slot.",
                    nameof(equipment)
                );
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Loadout other) =>
            Accessory == other.Accessory
         && Armor == other.Armor
         && Weapon == other.Weapon;

        protected override int GetHashCodeExplicit() => (Accessory, Armor, Weapon).GetHashCode();

        #endregion
    }
}
