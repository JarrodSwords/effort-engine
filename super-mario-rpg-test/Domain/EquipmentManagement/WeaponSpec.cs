using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class WeaponSpec : ValueObjectSpec<Weapon>
    {
        #region Protected Interface

        protected override ValueObject<Weapon> CreateValueObject() => new Weapon("Hammer");

        #endregion
    }
}
