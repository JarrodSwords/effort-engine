using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Loadout : ValueObject
    {
        #region Public Interface

        public Statistics Statistics => Weapon.Statistics;
        public Equipment Weapon { get; set; }

        public Loadout Equip(Equipment equipment)
        {
            Weapon = equipment;
            return this;
        }

        #endregion

        #region Equality

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Weapon;
        }

        #endregion
    }
}
