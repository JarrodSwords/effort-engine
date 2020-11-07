using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.EquipmentManagement;
using Xunit;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class CombatantSpec : EntitySpec
    {
        #region Test Methods

        protected override Entity CreateEntity() => new Combatant();
        protected override Entity CreateEntity(Guid id) => new Combatant(id);

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        public void WhenEquipping_CombatantUpdated(EquipmentType equipmentType)
        {
            var equipment = EquipmentFactory.Instance.Create(equipmentType);
            var combatant = new Combatant();

            combatant.Equip(equipment);

            combatant.Loadout[equipment.Slot].Should().Be(equipment);
        }

        #endregion
    }
}
