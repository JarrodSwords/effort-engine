using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class EquipmentSpec : EntitySpec
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

        protected override Entity CreateEntity() =>
            new Equipment(
                "Shirt",
                Slot.Armor,
                StatFactory.Instance.Create(EquipmentType.Shirt),
                Characters.Mario
            );

        protected override Entity CreateEntity(Guid id) =>
            new Equipment(
                "Shirt",
                Slot.Armor,
                StatFactory.Instance.Create(EquipmentType.Shirt),
                Characters.Mario,
                id
            );

        #endregion
    }
}
