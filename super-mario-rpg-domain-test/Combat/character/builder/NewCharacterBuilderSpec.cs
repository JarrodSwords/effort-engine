using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.StatFactory;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class NewCharacterBuilderSpec : CharacterBuilderSpec
    {
        #region Core

        private readonly NewCharacterBuilder _builder;

        public NewCharacterBuilderSpec()
        {
            _builder = new NewCharacterBuilder();
        }

        #endregion

        #region Private Interface

        private Character CreateCharacter()
        {
            Director.Configure(_builder);
            return _builder.Build();
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData(CharacterTypes.Mario, 1, 0)]
        [InlineData(CharacterTypes.Mallow, 2, 30)]
        public void WhenBuilding_NewCharacter(
            CharacterTypes characterType,
            byte expectedLevel,
            ushort expectedXp
        )
        {
            var expectedStats = CreateStats(characterType);

            _builder.For(characterType);
            var character = CreateCharacter();

            character.Progression.CurrentLevel.Value.Should().Be(expectedLevel);
            character.Progression.Xp.Value.Should().Be(expectedXp);
            character.NaturalStats.Should().Be(expectedStats);
        }

        public override void WhenBuilding_WithEquipment_ItemsAreEquipped()
        {
            _builder.For(CharacterTypes.Toadstool);

            var toadstool = CreateCharacter();

            toadstool.IsEquipped(PolkaDress).Should().BeTrue();
            toadstool.IsEquipped(SlapGlove).Should().BeTrue();
            toadstool.EffectiveStats.Should().Be(Aggregate(toadstool.NaturalStats, PolkaDress.Stats, SlapGlove.Stats));
        }

        #endregion
    }
}
