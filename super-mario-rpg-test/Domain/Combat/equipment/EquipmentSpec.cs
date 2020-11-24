using System;
using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Combat;
using static SuperMarioRpg.Domain.Combat.Equipment;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class EquipmentSpec : EntitySpec
    {
        #region Protected Interface

        protected override Entity CreateEntity() => Shirt;

        protected override Entity CreateEntity(Guid id) =>
            CreateEquipment(
                EquipmentType.Shirt,
                EquipmentSlot.Armor,
                CharacterTypes.Mario,
                "Shirt",
                null,
                id
            );

        #endregion
    }
}
