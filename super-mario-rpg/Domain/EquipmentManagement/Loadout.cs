using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        private readonly IDictionary<EquipmentType, Equipment> _equipment;

        public Loadout(IDictionary<EquipmentType, Equipment> equipment = null)
        {
            _equipment = equipment ?? new Dictionary<EquipmentType, Equipment>();
        }

        #endregion

        #region Public Interface

        public Equipment this[EquipmentType equipmentType] => _equipment[equipmentType];

        public Loadout Equip(Equipment equipment)
        {
            var loadout = _equipment;

            if (loadout.ContainsKey(equipment.EquipmentType))
                loadout[equipment.EquipmentType] = equipment;
            else
                loadout.Add(equipment.EquipmentType, equipment);

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
