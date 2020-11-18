using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public partial class Loadout : ValueObject<Loadout>
    {
        #region Core

        private readonly Dictionary<Slot, Equipment> _equipment;
        public static Loadout Default = new NullLoadout();

        public Loadout(params Equipment[] equipment)
        {
            _equipment = equipment.ToDictionary(x => x.Slot);

            if (_equipment.Count < 3)
                foreach (var e in Default._equipment.Select(x => x.Value).Where(x => !_equipment.ContainsKey(x.Slot)))
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

        public IEnumerable<Equipment> GetIncompatible(CharacterTypes characterType) =>
            _equipment
                .Where(x => !x.Value.IsCompatible(characterType))
                .Select(x => x.Value);

        public bool IsCompatible(CharacterTypes characterType) =>
            _equipment
                .Select(x => x.Value.CompatibleCharacterTypes)
                .Aggregate(characterType, (x, y) => x & y)
          > 0;

        public Loadout Unequip(Id id)
        {
            return new Loadout(_equipment.Select(x => x.Value).Where(x => x.Id != id).ToArray());
        }

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
