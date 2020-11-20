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

        #region Test Methods

        protected override Entity CreateEntity() => _mario;
        protected override Entity CreateEntity(Guid id) => _manualBuilder.WithId(id).Build();

        [Theory]
        [InlineData(EquipmentType.Hammer)]
        [InlineData(EquipmentType.Hammer, EquipmentType.Shirt, EquipmentType.JumpShoes)]
        public void EffectiveStatsAreSumOfNaturalStatsAndLoadout(params EquipmentType[] equipmentTypes)
        {
            var equipment = CreateEquipment(equipmentTypes).ToArray();
            _manualBuilder.Add(equipment).WithNaturalStats(20, 0, 20, 10, 2, 20);
            var expectedStats = CreateStats(CharacterTypes.Mario)
                              + equipment.Select(x => x.Stats).Aggregate((x, y) => x + y);

            _director.Configure(_manualBuilder);
            var character = _manualBuilder.Build();

            character.EffectiveStats.Should().BeEquivalentTo(expectedStats);
        }

        [Fact]
        public void WhenAddingXp_WithSufficientXpToLevel_LevelIncrements()
        {
            _mario.Add(CreateXp(16));

            _mario.Level.Value.Should().Be(2);
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

            _mario.IsEquipped(equipment).Should().BeTrue();
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

        [Fact]
        public void WhenLevelingUp_StatsChange()
        {
            var rewardStats = CreateStats(3, 2, 5, 2, 2);
            var expectedNaturalStats = _mario.NaturalStats + rewardStats;

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

            _mario.IsEquipped(equipment).Should().BeFalse();
            _mario.EffectiveStats.Should().Be(_mario.NaturalStats);
        }

        #endregion
    }
}
