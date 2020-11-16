using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class LoadoutSpec : ValueObjectSpec<Loadout>
    {
        #region Test Methods

        protected override ValueObject<Loadout> CreateValueObject() => new Loadout();

        [Fact]
        public void WhenInstantiating_WithMultipleItemsInSameSlot_ExceptionIsThrown()
        {
            Action createInvalidLoadout = () =>
            {
                var loadout = new Loadout(
                    Create(EquipmentType.Shirt),
                    Create(EquipmentType.Shirt)
                );
            };

            createInvalidLoadout.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
