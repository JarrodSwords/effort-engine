using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        private readonly Dictionary<Slot, Equipment> _equipment;

        public static Loadout NullLoadout = new Loadout();

        private Loadout()
        {
            _equipment = new List<Equipment>
            {
                Equipment.NullAccessory,
                Equipment.NullArmor,
                Equipment.NullWeapon
            }.ToDictionary(x => x.Slot);
        }

        public Loadout(params Equipment[] equipment)
        {
            _equipment = equipment.ToDictionary(x => x.Slot);

            foreach (var e in NullLoadout._equipment.Select(x => x.Value).Where(x => !_equipment.ContainsKey(x.Slot)))
                _equipment.Add(e.Slot, e);

            Stats = CalculateStats();
        }

        private Loadout(Loadout previous, Equipment equipment)
        {
            _equipment = previous._equipment;

            if (_equipment.ContainsKey(equipment.Slot))
                _equipment[equipment.Slot] = equipment;
            else
                _equipment.Add(equipment.Slot, equipment);

            Stats = CalculateStats();
        }

        #endregion

        #region Public Interface

        public Stats Stats { get; }
        public Equipment Accessory => GetEquipment(Slot.Accessory);
        public Equipment Armor => GetEquipment(Slot.Armor);
        public Equipment Weapon => GetEquipment(Slot.Weapon);

        public Loadout Equip(Equipment equipment) => new Loadout(this, equipment);

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

        private Stats CalculateStats() => Stats.Aggregate(_equipment.Select(x => x.Value.Stats).ToArray());

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
