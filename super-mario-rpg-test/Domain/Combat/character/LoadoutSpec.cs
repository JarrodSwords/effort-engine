using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class LoadoutSpec : ValueObjectSpec
    {
        #region Test Methods

        protected override ValueObject CreateValueObject() => new Loadout();

        [Fact]
        public void WhenEquipping_StatusesAreAggregated()
        {
            var loadout = new Loadout();

            loadout = loadout.Equip(ExpBooster);

            loadout.GetStatuses().Should().Be(ExpBooster.Status);
        }

        #endregion
    }
}
