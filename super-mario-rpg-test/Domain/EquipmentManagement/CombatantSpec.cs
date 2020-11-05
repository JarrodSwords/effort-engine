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
        [InlineData(Equippable.Hammer)]
        [InlineData(Equippable.Shirt)]
        public void WhenEquipping_CombatantUpdated(Equippable equippable)
        {
            var equipment = EquipmentFactory.Instance.Create(equippable);
            var combatant = new Combatant();

            combatant.Equip(equipment);

            combatant.Loadout[equipment.EquipmentType].Should().Be(equipment);
        }

        #endregion
    }
}
