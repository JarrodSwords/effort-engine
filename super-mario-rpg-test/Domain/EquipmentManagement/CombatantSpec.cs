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
        public void WhenEquippingArmor_ArmorIsSet()
        {
            var armor = new Armor("Shirt");
            var combatant = new Combatant();

            combatant.Equip(armor);

            combatant.Loadout.Armor.Should().Be(armor);
        }

        [Fact]
        public void WhenEquippingWeapon_WeaponIsSet()
        {
            var weapon = new Weapon("Hammer");
            var combatant = new Combatant();

            combatant.Equip(weapon);

            combatant.Loadout.Weapon.Should().Be(weapon);
        }

        #endregion
    }
}
