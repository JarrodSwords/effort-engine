using System;
using System.Linq;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class CharacterSpec : EntitySpec
    {
        #region Core

        private readonly Director _director;

        public CharacterSpec()
        {
            _director = new Director();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => new CharacterBuilder(Characters.Mario).Build();
        protected override Entity CreateEntity(Guid id) => new CharacterBuilder(Characters.Mario).WithId(id).Build();

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout(params EquipmentType[] equipmentTypes)
        {
            var equipment = Create(equipmentTypes).ToArray();
            var builder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(equipment);

            _director.ConfigureCharacter(builder);
            var character = builder.Build();

            var expectedStats = character.NaturalStats + equipment.Select(x => x.Stats).Aggregate((x, y) => x + y);

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenEquipping_WithValidEquipment_LoadoutUpdateIsExpected()
        {
            var builder = new CharacterBuilder(Characters.Mario);
            _director.ConfigureCharacter(builder);
            var character = builder.Build();

            character.Equip(Hammer);

            character.Weapon.Should().Be(Hammer);
        }

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            var builder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(Hammer, JumpShoes, Shirt);

            _director.ConfigureCharacter(builder);

            var character = builder.Build();

            character.Loadout.Accessory.Should().Be(JumpShoes);
            character.Loadout.Armor.Should().Be(Shirt);
            character.Loadout.Weapon.Should().Be(Hammer);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void WhenInstantiating_WithInvalidEquipment_ExceptionIsThrown(params EquipmentType[] equipmentTypes)
        {
            var equipment = Create(equipmentTypes).ToArray();

            var builder = new CharacterBuilder(Characters.Mallow)
                .WithEquipment(equipment);

            _director.ConfigureCharacter(builder);

            Action createInvalidCharacter = () =>
            {
                var character = builder.Build();
            };

            createInvalidCharacter.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip: {string.Join(", ", equipment.ToList())}*");
        }

        #endregion
    }
}
