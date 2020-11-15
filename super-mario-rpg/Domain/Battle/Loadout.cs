using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        private readonly IDictionary<Slot, Equipment> _equipment;

        public Loadout(IDictionary<Slot, Equipment> equipment = null)
        {
            _equipment = equipment ?? new Dictionary<Slot, Equipment>();
        }

        #endregion

        #region Public Interface

        public Equipment this[Slot slot] => _equipment[slot];

        public Loadout Equip(Equipment equipment)
        {
            var loadout = _equipment;

            if (loadout.ContainsKey(equipment.Slot))
                loadout[equipment.Slot] = equipment;
            else
                loadout.Add(equipment.Slot, equipment);

            return new Loadout(loadout);
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Loadout other) =>
            _equipment.OrderBy(x => x.Key).SequenceEqual(
                other._equipment.OrderBy(x => x.Key)
            );

        protected override int GetHashCodeExplicit() => _equipment.GetHashCode();

        #endregion
    }
}
