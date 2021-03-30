using System;
using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;
using static SuperMarioRpg.Domain.Combat.Equipment;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class EquipmentSpec : EntitySpec
    {
        #region Protected Interface

        protected override Entity CreateEntity()
        {
            return Shirt;
        }

        protected override Entity CreateEntity(Guid id)
        {
            return CreateEquipment(
                EquipmentType.Shirt,
                EquipmentSlot.Armor,
                CharacterTypes.Mario,
                "Shirt",
                Buffs.None,
                id
            );
        }

        #endregion
    }
}
