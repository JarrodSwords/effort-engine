using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Combatant : Entity
    {
        #region Public Interface

        public Weapon Weapon { get; private set; }

        public void Equip(Weapon weapon)
        {
            Weapon = weapon;
        }

        #endregion
    }
}
