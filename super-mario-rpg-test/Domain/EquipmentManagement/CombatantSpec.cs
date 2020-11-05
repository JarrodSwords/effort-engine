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
        [InlineData(EquipmentType.Armor, "Shirt")]
        [InlineData(EquipmentType.Weapon, "Hammer")]
        public void WhenEquipping_CombatantUpdated(EquipmentType equipmentType, string name)
        {
            var equipment = new Equipment(equipmentType, name);
            var combatant = new Combatant();

            combatant.Equip(equipment);

            combatant.Loadout[equipmentType].Should().Be(equipment);
        }

        #endregion
    }
}
