using Effort.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class WeaponSpec : EquipmentSpec
    {
        #region Protected Interface

        protected override ValueObject<Equipment> CreateValueObject() => new Weapon("Hammer");

        #endregion
    }
}
