using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        private readonly Dictionary<Slot, Equipment> _equipment;

        private static readonly List<Equipment> NullEquipment = new List<Equipment>
        {
            Equipment.NullAccessory,
            Equipment.NullArmor,
            Equipment.NullWeapon
        };

        public Loadout(params Equipment[] equipment)
        {
            _equipment = equipment.ToDictionary(x => x.Slot);

            foreach (var e in NullEquipment.Where(x => !_equipment.ContainsKey(x.Slot)))
                _equipment.Add(e.Slot, e);
        }

        #endregion

        #region Public Interface

        public Equipment Accessory => GetEquipment(Slot.Accessory);
        public Equipment Armor => GetEquipment(Slot.Armor);
        public Equipment Weapon => GetEquipment(Slot.Weapon);

        public IEnumerable<Equipment> GetIncompatible(Characters character) =>
            _equipment
                .Where(x => !x.Value.IsCompatible(character))
                .Select(x => x.Value);

        public bool IsCompatible(Characters character) =>
            _equipment
                .Select(x => x.Value.CompatibleCharacters)
                .Aggregate(character, (x, y) => x & y)
          > 0;

        #endregion

        #region Private Interface

        private Equipment GetEquipment(Slot slot) => _equipment[slot];

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
