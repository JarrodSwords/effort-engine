using FluentAssertions;
using SuperMarioRpg.Domain.Old.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Old.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Old.Combat.StatFactory;
using static SuperMarioRpg.Domain.Old.Combat.Stats;

namespace SuperMarioRpg.Domain.Test.Old.Combat
{
    public class NewCharacterBuilderSpec : CharacterBuilderSpec
    {
        #region Core

        private readonly NewPlayerCharacterBuilder _builder;

        public NewCharacterBuilderSpec()
        {
            _builder = new NewPlayerCharacterBuilder();
        }

        #endregion

        #region Private Interface

        private PlayerCharacter CreateCharacter()
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
            character.Progression.Xp.Should().Be(expectedXp);
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
