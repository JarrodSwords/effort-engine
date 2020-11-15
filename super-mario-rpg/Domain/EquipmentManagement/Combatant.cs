using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Battle;

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

        public void Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
        }

        #endregion
    }
}
