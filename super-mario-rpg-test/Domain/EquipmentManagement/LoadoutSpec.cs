using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class LoadoutSpec : ValueObjectSpec<Loadout>
    {
        #region Protected Interface

        protected override ValueObject<Loadout> CreateValueObject() => new Loadout();

        #endregion
    }
}
