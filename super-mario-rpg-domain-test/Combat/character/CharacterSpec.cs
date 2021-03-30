using System;
using Effort.Domain;
using Effort.Domain.Test;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;
using static SuperMarioRpg.Domain.Combat.Progression;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Test.Combat
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

        protected override Entity CreateEntity()
        {
            return _mario;
        }

        protected override Entity CreateEntity(Guid id)
        {
            return _manualBuilder.WithId(id).Build();
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
        public void WhenAddingXp_OverMaximum_XpIsCapped()
        {
            var xp = CreateXp(10000);

            _mario.Add(xp);
            _mallow.Equip(ExpBooster).Add(xp);

            _mario.Progression.Xp.Should().Be(Max);
            _mario.Progression.Should().BeOfType<Maxed>();
            _mallow.Progression.Xp.Should().Be(Max);
            _mallow.Progression.Should().BeOfType<Maxed>();
        }

        [Fact]
        public void WhenAddingXp_WhileBoosted_GainDoubleXp()
        {
            _mario.Equip(ExpBooster).Add(CreateXp(500));

            _mario.Progression.Xp.Value.Should().Be(1000);
        }

        [Fact]
        public void WhenAddingXp_WhileMaxed_NoChange()
        {
            var marioProgression = _mario.Add(Max).Progression;
            var mallowProgression = _mallow.Add(Max).Equip(ExpBooster).Progression;
            var xp = CreateXp(1);

            _mario.Add(xp);
            _mallow.Add(xp);

            _mario.Progression.Should().Be(marioProgression);
            _mallow.Progression.Should().Be(mallowProgression);
        }

        [Fact]
        public void WhenAddingXp_WhileStandard_GainXp()
        {
            var xp = CreateXp(500);

            _mario.Add(xp);

            _mario.Progression.Xp.Should().Be(xp);
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
