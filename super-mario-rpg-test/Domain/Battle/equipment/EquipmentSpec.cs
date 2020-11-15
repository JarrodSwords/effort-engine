using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class EquipmentSpec : ValueObjectSpec<Equipment>
    {
        #region Test Methods

        [Fact]
        public void CanBeCloned()
        {
            var shirt1 = new Equipment("Shirt", Slot.Armor, new Stats(), Characters.Mario);
            var shirt2 = shirt1.Clone();

            shirt2.Should().NotBeSameAs(shirt1);
            shirt2.Should().BeEquivalentTo(shirt1);
        }

        protected override ValueObject<Equipment> CreateValueObject() =>
            new Equipment("shirt", Slot.Armor, new Stats(), Characters.Mario);

        #endregion
    }
}
