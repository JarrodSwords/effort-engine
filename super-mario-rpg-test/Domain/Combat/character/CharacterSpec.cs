using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.Progression;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class CharacterSpec : EntitySpec
    {
        #region Core

        private readonly Character _mallow;
        private readonly ManualCharacterBuilder _manualBuilder;
        private readonly Character _mario;

        public CharacterSpec()
        {
            var director = new Director();
            _manualBuilder = new ManualCharacterBuilder();

            var builder = new NewCharacterBuilder();
            director.Configure(builder);
            _mario = builder.Build();

            builder.For(CharacterTypes.Mallow);
            director.Configure(builder);
            _mallow = builder.Build();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => _mario;
        protected override Entity CreateEntity(Guid id) => _manualBuilder.WithId(id).Build();

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
            _mallow.Equip(ExpBooster).Add(CreateXp(5000));

            _mario.Progression.Xp.Should().Be(Max);
            _mallow.Progression.Xp.Should().Be(Max);
        }

        [Fact]
        public void WhenAddingXp_WhileMaxed_NothingChanges()
        {
            var progression = _mario.Add(Max).Progression;

            _mario.Add(CreateXp(1));

            _mario.Progression.Should().Be(progression);
        }

        [Fact]
        public void WhenAddingXp_WhileMaxedWithExpBooster_NothingChanges()
        {
            var p1 = _mario.Add(Max).Progression;
            var p2 = _mario.Equip(ExpBooster).Add(CreateXp(1)).Progression;
            p2.Should().BeEquivalentTo(p1);
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
        public void WhenEquipping_ItemWithNewStatus_StatusIsAdded()
        {
            _mario.Equip(ExpBooster);

            _mario.Status.Buffs.Contains(ExpBooster.Buffs).Should().BeTrue();
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
        public void WhenUnequipping_ItemIsUnequipped(EquipmentType equipmentType)
        {
            var equipment = CreateEquipment(equipmentType);

            _mario.Equip(equipment).Unequip(equipment);

            _mario.IsEquipped(equipment).Should().BeFalse();
            _mario.EffectiveStats.Should().Be(_mario.NaturalStats);
        }

        [Fact]
        public void WhenUnequipping_ItemProvidingStatus_StatusIsRemoved()
        {
            _mario.Equip(ExpBooster).Unequip(ExpBooster);

            _mario.Status.Buffs.Contains(ExpBooster.Buffs).Should().BeFalse();
        }

        #endregion
    }
}
