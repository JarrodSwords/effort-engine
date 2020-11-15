using System;
using System.Collections.Generic;
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

        [Fact]
        public void WhenInstantiating_WithDuplicateSlot_ExceptionIsThrown()
        {
            var equipment = new List<Equipment>
            {
                EquipmentFactory.Instance.Create(EquipmentType.Shirt),
                EquipmentFactory.Instance.Create(EquipmentType.Shirt)
            };

            Action createInvalidLoadout = () =>
            {
                var loadout = new Loadout(equipment);
            };

            createInvalidLoadout.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
