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
            _manualBuilder.For(CharacterTypes.Mallow);
            var character = CreateCharacter();
            var equipment = CreateEquipment(equipmentType);

            Action equipInvalidItem = () => { character.Equip(equipment); };

            equipInvalidItem.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip: {equipment}*");
        }

        [Fact]
        public void WhenGainingExperience_ExperienceIsExpected()
        {
            _director.Configure(_newBuilder);
            var character = _newBuilder.Build();
            var service = new GrowthService();

            service.DistributeExperience(new ExperiencePoints(50), character);

            character.ExperiencePoints.Value.Should().Be(50);
        }

        [Theory]
        [InlineData(15, 0)]
        [InlineData(16, 1)]
        [InlineData(50, 2)]
        public void WhenGainingExperience_LevelChanges(ushort experiencePoints, byte levelsGained)
        {
            _director.Configure(_newBuilder);
            var character = _newBuilder.Build();
            var expectedLevel = character.Level + new Level(levelsGained);

            var service = new GrowthService();
            service.DistributeExperience(new ExperiencePoints(experiencePoints), character);

            character.Level.Should().Be(expectedLevel);
        }

        [Theory]
        [InlineData(CharacterTypes.Mario, 1, 0)]
        [InlineData(CharacterTypes.Mallow, 2, 30)]
        public void WhenInstantiating_NewCharacter(
            CharacterTypes characterType,
            byte expectedLevel,
            ushort expectedExperiencePoints
        )
        {
            _newBuilder.For(characterType);
            _director.Configure(_newBuilder);
            var expectedStats = CreateStats(characterType);

            var character = _newBuilder.Build();

            character.Level.Value.Should().Be(expectedLevel);
            character.ExperiencePoints.Value.Should().Be(expectedExperiencePoints);
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

            Action createInvalidCharacter = () =>
            {
                var character = _manualBuilder.Build();
            };

            createInvalidCharacter.Should().Throw<ValidationException>()
                .WithMessage($"*Mallow cannot equip: {string.Join(", ", equipment.ToList())}*");
        }

        [Fact]
        public void WhenLevelingUp_StatsChange()
        {
            _director.Configure(_newBuilder);
            var character = _newBuilder.Build();
            var expectedNaturalStats = new Stats(23, 2, 25, 12, 4, 20);
            var service = new GrowthService();

            service.DistributeExperience(new ExperiencePoints(16), character);

            character.NaturalStats.Should().Be(expectedNaturalStats);
        }

        [Fact]
        public void WhenUnequipping_WithEquipmentId_LoadoutIsExpected()
        {
            _manualBuilder.Add(Shirt);
            var character = CreateCharacter();

            character.Unequip(Shirt.Id);

            character.Armor.Should().Be(Equipment.NullArmor);
            character.EffectiveStats.Should().Be(character.NaturalStats + character.Loadout.Stats);
        }

        #endregion
    }
}
