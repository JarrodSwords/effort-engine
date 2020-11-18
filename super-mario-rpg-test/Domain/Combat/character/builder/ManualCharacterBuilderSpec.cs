using FluentAssertions;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class ManualCharacterBuilderSpec : CharacterBuilderSpec
    {
        #region Core

        private readonly ManualCharacterBuilder _builder;

        public ManualCharacterBuilderSpec()
        {
            _builder = new ManualCharacterBuilder();
        }

        #endregion

        #region Public Interface

        public override void WhenInstantiating_WithEquipment_ItemsAreEquipped()
        {
            _builder.Add(EquipmentFactory.Hammer, EquipmentFactory.JumpShoes, EquipmentFactory.Shirt);

            var mario = CreateCharacter();

            mario.Accessory.Should().Be(EquipmentFactory.JumpShoes);
            mario.Armor.Should().Be(EquipmentFactory.Shirt);
            mario.Weapon.Should().Be(EquipmentFactory.Hammer);
            mario.EffectiveStats.Should().Be(
                mario.NaturalStats
              + EquipmentFactory.Hammer.Stats
              + EquipmentFactory.JumpShoes.Stats
              + EquipmentFactory.Shirt.Stats
            );
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
