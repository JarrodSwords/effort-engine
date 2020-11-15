using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        public Loadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
        {
            Accessory = accessory;
            Armor = armor;
            Weapon = weapon;
        }

        public Loadout(IReadOnlyCollection<Equipment> equipment)
        {
            ValidateEquipment(equipment);
            Armor = equipment.FirstOrDefault(x => x.Slot == Slot.Armor);
            Weapon = equipment.FirstOrDefault(x => x.Slot == Slot.Weapon);
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; }
        public Equipment Armor { get; }
        public Equipment Weapon { get; }

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
