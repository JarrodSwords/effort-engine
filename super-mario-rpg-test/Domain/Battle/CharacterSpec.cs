using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class CharacterSpec : EntitySpec
    {
        #region Core

        private readonly Director _director;
        private readonly Equipment _hammer;
        private readonly Equipment _jumpShoes;
        private readonly Equipment _shirt;

        public CharacterSpec()
        {
            _director = new Director();
            _hammer = EquipmentFactory.Instance.Create(EquipmentType.Hammer);
            _jumpShoes = EquipmentFactory.Instance.Create(EquipmentType.JumpShoes);
            _shirt = EquipmentFactory.Instance.Create(EquipmentType.Shirt);
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => new CharacterBuilder(Characters.Mario).Build();
        protected override Entity CreateEntity(Guid id) => new CharacterBuilder(Characters.Mario).WithId(id).Build();

        [Fact]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout()
        {
            var characterBuilder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(_hammer, _shirt, _jumpShoes);

            _director.ConfigureCharacter(characterBuilder);

            var character = characterBuilder.Build();
            var expectedStats = character.NaturalStats + _hammer.Stats + _jumpShoes.Stats + _shirt.Stats;

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            var characterBuilder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(_hammer, _shirt, _jumpShoes);

            _director.ConfigureCharacter(characterBuilder);

            var character = characterBuilder.Build();

            character.Loadout.Weapon.Should().Be(_hammer);
            character.Loadout.Armor.Should().Be(_shirt);
            character.Loadout.Accessory.Should().Be(_jumpShoes);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenInstantiating_WithInvalidEquipment_ExceptionIsThrown(EquipmentType equipmentType)
        {
            var equipment = EquipmentFactory.Instance.Create(equipmentType);
            var builder = new CharacterBuilder(Characters.Mallow).WithEquipment(equipment);

            _director.ConfigureCharacter(builder);

            Action createInvalidCharacter = () =>
            {
                var character = builder.Build();
            };

            createInvalidCharacter.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
