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
        private readonly Character _mallow;
        private readonly ManualCharacterBuilder _manualBuilder;
        private readonly Character _mario;

        public CharacterSpec()
        {
            _director = new Director();
            _manualBuilder = new ManualCharacterBuilder();

            var builder = new NewCharacterBuilder();
            _director.Configure(builder);
            _mario = builder.Build();

            builder.For(CharacterTypes.Mallow);
            _director.Configure(builder);
            _mallow = builder.Build();
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
            var remainder = _mario.Add(CreateXp(50));

            _mario.Xp.Value.Should().Be(16);
            remainder.Value.Should().Be(34);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenEquipping_CompatibleItem_ItemIsEquipped(EquipmentType equipmentType)
        {
            var equipment = CreateEquipment(equipmentType);

            _mario.Equip(equipment);

            _mario.GetEquipment(equipment.Slot).Should().Be(equipment);
            _mario.EffectiveStats.Should().Be(_mario.NaturalStats + equipment.Stats);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenEquipping_IncompatibleItem_ExceptionIsThrown(EquipmentType equipmentType)
        {
            var equipment = CreateEquipment(equipmentType);

            Action equipIncompatibleItem = () => { _mallow.Equip(equipment); };

            equipIncompatibleItem.Should().Throw<ValidationException>()
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
            // todo: move to builder specs

            var builder = new NewCharacterBuilder().For(characterType);
            _director.Configure(builder);
            var expectedStats = CreateStats(characterType);

            var character = builder.Build();

            character.Level.Value.Should().Be(expectedLevel);
            character.Xp.Value.Should().Be(expectedXp);
            character.NaturalStats.Should().Be(expectedStats);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void WhenInstantiating_WithInvalidEquipment_ExceptionIsThrown(params EquipmentType[] equipmentTypes)
        {
            // todo: move to builder specs

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
            var expectedNaturalStats = CreateStats(23, 2, 25, 12, 4, 20);

            _mario.Add(CreateXp(16));

            _mario.NaturalStats.Should().Be(expectedNaturalStats);
        }

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Shirt)]
        [InlineData(EquipmentType.JumpShoes)]
        public void WhenUnequipping_WithEquipmentId_ItemIsUnequipped(EquipmentType equipmentType)
        {
            var equipment = CreateEquipment(equipmentType);

            _mario.Equip(equipment).Unequip(equipment.Id);

            _mario.GetEquipment(equipment.Slot).Should().NotBe(equipment);
            _mario.EffectiveStats.Should().Be(_mario.NaturalStats);
        }

        #endregion
    }
}
