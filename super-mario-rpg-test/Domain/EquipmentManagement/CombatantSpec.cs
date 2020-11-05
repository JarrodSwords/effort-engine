using FluentAssertions;
using SuperMarioRpg.Domain.EquipmentManagement;
using Xunit;

namespace SuperMarioRpg.Test.Domain.EquipmentManagement
{
    public class CombatantSpec
    {
        #region Test Methods

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
