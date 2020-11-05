using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        public Loadout()
        {
        }

        public Loadout(Armor armor, Weapon weapon)
        {
            Armor = armor;
            Weapon = weapon;
        }

        #endregion

        #region Public Interface

        public Armor Armor { get; }
        public Weapon Weapon { get; }

        public Loadout Equip(Armor armor) => new Loadout(armor, Weapon);
        public Loadout Equip(Weapon weapon) => new Loadout(Armor, weapon);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Loadout other) => throw new NotImplementedException();

        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
