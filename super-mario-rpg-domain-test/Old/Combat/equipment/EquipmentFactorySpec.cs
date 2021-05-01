using FluentAssertions;
using SuperMarioRpg.Domain.Old.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Old.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Old.Combat.Stats;

namespace SuperMarioRpg.Domain.Test.Old.Combat
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
            short hp = 0,
            short specialAttack = 0,
            short specialDefense = 0,
            short speed = 0
        )
        {
            var expectedStats = CreateStats(attack, defense, hp, specialAttack, specialDefense, speed);

            var equipment = CreateEquipment(equipmentType);

            equipment.Stats.Should().BeEquivalentTo(expectedStats);
        }

        #endregion
    }
}
