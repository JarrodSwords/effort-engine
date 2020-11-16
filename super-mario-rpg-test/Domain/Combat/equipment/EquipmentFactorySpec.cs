using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain
{
    public class EquipmentFactorySpec
    {
        #region Test Methods

        [Theory]
        [InlineData(EquipmentType.Hammer, 10)]
        [InlineData(EquipmentType.JumpShoes, 0, 1, 0, 5, 1, 2)]
        [InlineData(EquipmentType.Shirt, 0, 6, 0, 0, 6)]
        public void HasExpectedStats(
            EquipmentType equipmentType,
            short attack = 0,
            short defense = 0,
            short hitPoints = 0,
            short specialAttack = 0,
            short specialDefense = 0,
            short speed = 0
        )
        {
            var expectedStats = new Stats(attack, defense, hitPoints, specialAttack, specialDefense, speed);

            var equipment = EquipmentFactory.Instance.Create(equipmentType);

            equipment.Stats.Should().BeEquivalentTo(expectedStats);
        }

        #endregion
    }
}
