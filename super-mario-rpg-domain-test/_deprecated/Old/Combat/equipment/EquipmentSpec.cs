using System;
using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Old.Combat;
using static SuperMarioRpg.Domain.Old.Combat.Equipment;
using static SuperMarioRpg.Domain.Old.Combat.EquipmentFactory;

namespace SuperMarioRpg.Domain.Test.Old.Combat
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
                Buffs.None,
                id
            );

        #endregion
    }
}
