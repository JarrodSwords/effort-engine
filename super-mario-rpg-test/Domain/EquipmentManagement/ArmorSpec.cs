using Effort.Domain;
using SuperMarioRpg.Domain.EquipmentManagement;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class ArmorSpec : EquipmentSpec
    {
        #region Protected Interface

        protected override ValueObject<Equipment> CreateValueObject() => new Armor("Shirt");

        #endregion
    }
}
