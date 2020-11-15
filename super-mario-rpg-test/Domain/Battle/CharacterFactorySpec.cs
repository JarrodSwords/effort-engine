using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class CharacterFactorySpec
    {
        #region Test Methods

        [Theory]
        [InlineData(CharacterType.Mario, 20, 0, 20, 10, 2, 20)]
        public void HasExpectedStats(
            CharacterType characterType,
            short attack = 0,
            short defense = 0,
            short hitPoints = 0,
            short specialAttack = 0,
            short specialDefense = 0,
            short speed = 0
        )
        {
            var expectedStats = new Stats(attack, defense, hitPoints, specialAttack, specialDefense, speed);

            var character = CharacterFactory.Instance.Create(characterType);

            character.Stats.Should().BeEquivalentTo(expectedStats);
        }

        #endregion
    }
}
