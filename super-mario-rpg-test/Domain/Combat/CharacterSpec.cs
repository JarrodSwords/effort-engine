using System;
using System.Linq;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
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

        #region Private Interface

        private static Equipment[] GetEquipment(params EquipmentType[] equipmentTypes)
        {
            return equipmentTypes.Select(x => EquipmentFactory.Instance.Create(x)).ToArray();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => new CharacterBuilder(Characters.Mario).Build();
        protected override Entity CreateEntity(Guid id) => new CharacterBuilder(Characters.Mario).WithId(id).Build();

        [Theory]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout(params EquipmentType[] equipmentTypes)
        {
            var equipment = GetEquipment(equipmentTypes);
            var builder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(equipment);

            _director.ConfigureCharacter(builder);
            var character = builder.Build();

            var expectedStats = character.NaturalStats
                              + _hammer.Stats
                              + _jumpShoes.Stats
                              + _shirt.Stats;

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            var builder = new CharacterBuilder(Characters.Mario)
                .WithEquipment(_hammer, _shirt, _jumpShoes);

            _director.ConfigureCharacter(builder);

            var character = builder.Build();

            character.Loadout.Accessory.Should().Be(_jumpShoes);
            character.Loadout.Armor.Should().Be(_shirt);
            character.Loadout.Weapon.Should().Be(_hammer);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void WhenInstantiating_WithInvalidEquipment_ExceptionIsThrown(params EquipmentType[] equipmentTypes)
        {
            var equipment = GetEquipment(equipmentTypes);

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
