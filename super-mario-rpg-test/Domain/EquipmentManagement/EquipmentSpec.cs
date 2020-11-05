using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class EquipmentSpec : ValueObjectSpec<Equipment>
    {
        #region Protected Interface

        protected override ValueObject<Equipment> CreateValueObject() => new Equipment(EquipmentType.Armor, "shirt");

        #endregion
    }
}
