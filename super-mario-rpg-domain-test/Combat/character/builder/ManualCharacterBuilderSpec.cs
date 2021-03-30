using System;
using System.Linq;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Test.Combat
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

        #region Private Interface

        private Character CreateCharacter()
        {
            Director.Configure(_builder);
            return _builder.Build();
        }

        #endregion

        #region Test Methods

        public override void WhenBuilding_WithEquipment_ItemsAreEquipped()
        {
            _builder.Add(Hammer, JumpShoes, Shirt);

            var mario = CreateCharacter();

            mario.IsEquipped(Hammer).Should().BeTrue();
            mario.IsEquipped(JumpShoes).Should().BeTrue();
            mario.IsEquipped(Shirt).Should().BeTrue();
            mario.EffectiveStats.Should().Be(Aggregate(mario.NaturalStats, Hammer.Stats, JumpShoes.Stats, Shirt.Stats));
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void WhenBuilding_WithInvalidEquipment_ExceptionIsThrown(params EquipmentType[] equipmentTypes)
        {
            var equipment = CreateEquipment(equipmentTypes).ToArray();
            _builder.For(CharacterTypes.Mallow).Add(equipment);
            Director.Configure(_builder);

            Action createInvalidCharacter = () => { _builder.Build(); };

            createInvalidCharacter.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip {Hammer}*");
        }

        #endregion
    }
}
