using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Test.Domain.Combat
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

        #region Public Interface

        public override void WhenInstantiating_WithEquipment_ItemsAreEquipped()
        {
            _builder.For(CharacterTypes.Toadstool);

            var toadstool = CreateCharacter();

            toadstool.Armor.Should().Be(PolkaDress);
            toadstool.Weapon.Should().Be(SlapGlove);
            toadstool.EffectiveStats.Should().Be(toadstool.NaturalStats + PolkaDress.Stats + SlapGlove.Stats);
        }

        #endregion

        #region Private Interface

        private Character CreateCharacter()
        {
            Director.Configure(_builder);
            return _builder.Build();
        }

        #endregion
    }
}
