using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class LoadoutSpec : ValueObjectSpec<Loadout>
    {
        #region Test Methods

        protected override ValueObject<Loadout> CreateValueObject() => new Loadout();

        [Theory]
        [InlineData(EquipmentType.Shirt, EquipmentType.Shirt, EquipmentType.Hammer)]
        [InlineData(EquipmentType.JumpShoes, EquipmentType.JumpShoes, EquipmentType.Hammer)]
        [InlineData(EquipmentType.JumpShoes, EquipmentType.Shirt, EquipmentType.Shirt)]
        public void WhenInstantiating_WithMismatchedEquipment_ExceptionIsThrown(
            EquipmentType accessory,
            EquipmentType armor,
            EquipmentType weapon
        )
        {
            Action createInvalidLoadout = () =>
            {
                var loadout = new Loadout(
                    EquipmentFactory.Instance.Create(accessory),
                    EquipmentFactory.Instance.Create(armor),
                    EquipmentFactory.Instance.Create(weapon)
                );
            };

            createInvalidLoadout.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
