using System;
using Effort.Domain;
using Effort.Domain.Test;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.Equipment;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayerCharacterSpec : EntitySpec
    {
        #region Core

        private readonly PlayerCharacter _mario;

        public PlayerCharacterSpec()
        {
            _mario = new PlayerCharacter(new TestBuilder());
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => _mario;
        protected override Entity CreateEntity(Guid id) => new PlayerCharacter(new TestBuilder().With(id));

        [Fact]
        public void WhenEquipping_ValidEquipment_CorrectSlotIsUpdated()
        {
            _mario.Equip(Hammer);

            _mario.Weapon.Should().Be(Hammer);
        }

        [Fact]
        public void WhenEquipping_ValidEquipment_EffectiveStatsAreUpdated()
        {
            _mario.Equip(Hammer);

            _mario.EffectiveStatistics.Should().Be(_mario.NaturalStatistics + Hammer.Statistics);
        }

        #endregion
    }
}
