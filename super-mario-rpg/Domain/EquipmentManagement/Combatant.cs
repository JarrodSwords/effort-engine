using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Combatant : Entity
    {
        #region Core

        public Combatant(Guid id = new Guid()) : base(id)
        {
            Loadout = new Loadout();
        }

        #endregion

        #region Public Interface

        public Loadout Loadout { get; private set; }

        public void Equip(Armor armor)
        {
            Loadout = Loadout.Equip(armor);
        }

        public void Equip(Weapon weapon)
        {
            Loadout = Loadout.Equip(weapon);
        }

        #endregion
    }
}
