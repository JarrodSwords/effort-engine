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

        [Fact]
        public void WhenEquippingWeapon_WeaponIsSet()
        {
            var weapon = new Weapon("Hammer");
            var combatant = new Combatant();

            combatant.Equip(weapon);

            combatant.Weapon.Should().Be(weapon);
        }

        #endregion
    }
}
