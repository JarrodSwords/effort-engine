using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class ArmorSpec : ValueObjectSpec<Armor>
    {
        #region Protected Interface

        protected override ValueObject<Armor> CreateValueObject() => new Armor("Shirt");

        #endregion
    }
}
