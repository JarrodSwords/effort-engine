using System;
using System.Linq;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.Level;
using static SuperMarioRpg.Domain.Combat.StatFactory;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class CharacterSpec : EntitySpec
    {
        #region Core

        private readonly Director _director;
        private readonly ManualCharacterBuilder _manualBuilder;
        private readonly NewCharacterBuilder _newBuilder;

        public CharacterSpec()
        {
            _director = new Director();
            _manualBuilder = new ManualCharacterBuilder();
            _newBuilder = new NewCharacterBuilder();
        }

        #endregion

        #region Private Interface

        private Character CreateCharacter()
        {
            _director.Configure(_manualBuilder);
            return _manualBuilder.Build();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => _manualBuilder.Build();
        protected override Entity CreateEntity(Guid id) => _manualBuilder.WithId(id).Build();

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout(params EquipmentType[] equipmentTypes)
        {
            var equipment = CreateEquipment(equipmentTypes).ToArray();
            _manualBuilder.Add(equipment).WithNaturalStats(20, 0, 20, 10, 2, 20);
            var character = CreateCharacter();

            var expectedStats = CreateStats(CharacterTypes.Mario)
                              + equipment.Select(x => x.Stats).Aggregate((x, y) => x + y);

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenAddingXp_WithSufficientXpToLevel_LevelIncrements()
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            var character = builder.Build();
            var expectedLevel = character.Level + CreateLevel(1);
            var xp = character.ToNext;

            character.Add(xp);

            character.Level.Should().Be(expectedLevel);
        }

        [Fact]
        public void WhenAddingXp_XpIsUpdated()
        {
            _director.Configure(_newBuilder);
            var character = _newBuilder.Build();

            var remainder = character.Add(CreateXp(50));

            character.Xp.Value.Should().Be(16);
            remainder.Value.Should().Be(34);
        }

        [Fact]
        public void WhenEquipping_WithEquipment_LoadoutIsExpected()
        {
            var character = CreateCharacter();

            character.Equip(Hammer).Equip(Shirt).Equip(JumpShoes);

            character.Accessory.Should().Be(JumpShoes);
            character.Armor.Should().Be(Shirt);
            character.Weapon.Should().Be(Hammer);
            character.EffectiveStats.Should().Be(character.NaturalStats + Shirt.Stats + Hammer.Stats + JumpShoes.Stats);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenEquipping_WithInvalidEquipment_LoadoutIsExpected(EquipmentType equipmentType)
        {
            _manualBuilder.For(CharacterTypes.Mallow);
            var character = CreateCharacter();
            var equipment = CreateEquipment(equipmentType);

            Action equipInvalidItem = () => { character.Equip(equipment); };

            equipInvalidItem.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip {equipment}.*");
        }

        [Theory]
        [InlineData(CharacterTypes.Mario, 1, 0)]
        [InlineData(CharacterTypes.Mallow, 2, 30)]
        public void WhenInstantiating_NewCharacter(
            CharacterTypes characterType,
            byte expectedLevel,
            ushort expectedXp
        )
        {
            _newBuilder.For(characterType);
            _director.Configure(_newBuilder);
            var expectedStats = CreateStats(characterType);

            var character = _newBuilder.Build();

            character.Level.Value.Should().Be(expectedLevel);
            character.Xp.Value.Should().Be(expectedXp);
            character.NaturalStats.Should().Be(expectedStats);
        }

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            _manualBuilder.Add(Hammer, JumpShoes, Shirt);

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
            _manualBuilder.For(CharacterTypes.Mallow).Add(equipment);
            _director.Configure(_manualBuilder);

            Action createInvalidCharacter = () => { _manualBuilder.Build(); };

            createInvalidCharacter.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip {Hammer}*");
        }

        [Fact]
        public void WhenLevelingUp_StatsChange()
        {
            _director.Configure(_newBuilder);
            var character = _newBuilder.Build();
            var expectedNaturalStats = CreateStats(23, 2, 25, 12, 4, 20);

            character.Add(CreateXp(16));

            character.NaturalStats.Should().Be(expectedNaturalStats);
        }

        [Fact]
        public void WhenUnequipping_WithEquipmentId_LoadoutIsExpected()
        {
            _manualBuilder.Add(Shirt);
            var character = CreateCharacter();

            character.Unequip(Shirt.Id);

            character.Armor.Should().Be(Equipment.DefaultArmor);
            character.EffectiveStats.Should().Be(character.NaturalStats);
        }

        #endregion
    }
}
