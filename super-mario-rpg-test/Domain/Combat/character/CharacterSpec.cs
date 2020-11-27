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
        public void WhenAddingXp_GainXp()
        {
            var xp = CreateXp(500);

            _mario.Add(xp);

            _mario.Progression.Xp.Should().Be(xp);
        }

        [Theory]
        [InlineData(15, 1)]
        [InlineData(16, 2)]
        [InlineData(50, 3)]
        public void WhenAddingXp_LevelIsUpdated(ushort xpValue, byte expectedLevel)
        {
            _mario.Add(CreateXp(xpValue));

            _mario.Progression.CurrentLevel.Value.Should().Be(expectedLevel);
        }

        [Fact]
        public void WhenAddingXp_OverMaximum_XpIsLimited()
        {
            _mario.Add(CreateXp(10000));

            _mario.Progression.Xp.Value.Should().Be(9999);
        }

        [Fact]
        public void WhenAddingXp_WhileMaxed_NothingChanges()
        {
            _mario.Add(CreateXp(9999));
            var progression = _mario.Progression;

            _mario.Add(CreateXp(1));

            _mario.Progression.Should().Be(progression);
        }

        [Fact]
        public void WhenAddingXp_WhileMaxedWithExpBooster_NothingChanges()
        {
            var p1 = _mario.Add(CreateXp(9999)).Equip(ExpBooster).Progression;
            var p2 = _mario.Add(CreateXp(1)).Progression;
            p2.Should().Be(p1);
        }

        [Fact]
        public void WhenAddingXp_WithExpBooster_GainDoubleXp()
        {
            _mario.Equip(ExpBooster).Add(CreateXp(500));

            _mario.Progression.Xp.Value.Should().Be(1000);
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

            _mario.Equip(equipment).Unequip(equipment);

            _mario.IsEquipped(equipment).Should().BeFalse();
            _mario.EffectiveStats.Should().Be(_mario.NaturalStats);
        }

        #endregion
    }
}
