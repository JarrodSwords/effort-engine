using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Loadout : ValueObject
    {
        #region Creation

        public Loadout(Equipment weapon = default)
        {
            Weapon = weapon;
        }

        #endregion

        #region Public Interface

        public Statistics Statistics => Weapon.Statistics;
        public Equipment Weapon { get; }

        public Loadout Equip(Equipment equipment) => new(equipment);

        #endregion

        #region Equality

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Weapon;
        }

        #endregion
    }
}
