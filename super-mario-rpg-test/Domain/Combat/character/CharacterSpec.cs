using System;
using System.Linq;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class CharacterSpec : EntitySpec
    {
        #region Core

        private readonly CharacterBuilder _builder;
        private readonly Director _director;

        public CharacterSpec()
        {
            _builder = new CharacterBuilder();
            _director = new Director();
        }

        #endregion

        #region Private Interface

        private Character CreateCharacter()
        {
            _director.ConfigureCharacter(_builder);
            return _builder.Build();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => new CharacterBuilder().Build();
        protected override Entity CreateEntity(Guid id) => new CharacterBuilder().WithId(id).Build();

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout(params EquipmentType[] equipmentTypes)
        {
            var equipment = CreateEquipment(equipmentTypes).ToArray();
            _builder.WithEquipment(equipment);
            var expectedStats = CreateStats(Characters.Mario)
                              + equipment.Select(x => x.Stats).Aggregate((x, y) => x + y);

            var character = CreateCharacter();

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenEquipping_WithEquipment_LoadoutIsExpected()
        {
            var character = CreateCharacter();

            character.Equip(Hammer).Equip(Shirt).Equip(JumpShoes);

            character.Accessory.Should().Be(JumpShoes);
            character.Armor.Should().Be(Shirt);
            character.Weapon.Should().Be(Hammer);
            character.EffectiveStats.Should().Be(character.NaturalStats + character.Loadout.Stats);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenEquipping_WithInvalidEquipment_LoadoutIsExpected(EquipmentType equipmentType)
        {
            _builder.WithCharacterType(Characters.Mallow);
            var character = CreateCharacter();
            var equipment = CreateEquipment(equipmentType);

            Action equipInvalidItem = () => { character.Equip(equipment); };

            equipInvalidItem.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip: {equipment}*");
        }

        [Fact]
        public void WhenGainingExperience_ExperienceIsExpected()
        {
            var character = CreateCharacter();

            character.GainExperience(100).GainExperience(50);

            character.Experience.Should().Be(150);
        }

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            _builder.WithEquipment(Hammer, JumpShoes, Shirt);

            var character = CreateCharacter();

            character.Accessory.Should().Be(JumpShoes);
            character.Armor.Should().Be(Shirt);
            character.Weapon.Should().Be(Hammer);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void WhenInstantiating_WithInvalidEquipment_ExceptionIsThrown(params EquipmentType[] equipmentTypes)
        {
            var equipment = CreateEquipment(equipmentTypes).ToArray();
            _builder.WithCharacterType(Characters.Mallow).WithEquipment(equipment);
            _director.ConfigureCharacter(_builder);

            Action createInvalidCharacter = () =>
            {
                var character = _builder.Build();
            };

            createInvalidCharacter.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip: {string.Join(", ", equipment.ToList())}*");
        }

        [Fact]
        public void WhenUnequipping_WithEquipmentId_LoadoutIsExpected()
        {
            _builder.WithEquipment(Shirt);
            var character = CreateCharacter();

            character.Unequip(Shirt.Id);

            character.Armor.Should().Be(Equipment.NullArmor);
            character.EffectiveStats.Should().Be(character.NaturalStats + character.Loadout.Stats);
        }

        #endregion
    }
}
