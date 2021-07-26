using System;
using Effort.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.Equipment;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayableCharacterSpec : CharacterSpec
    {
        #region Core

        private readonly PlayableCharacter _mario;

        public PlayableCharacterSpec()
        {
            _mario = new MarioBuilder();
        }

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => _mario;
        protected override Entity CreateEntity(Guid id) => new MarioBuilder().With(id);

        [Fact]
        public void WhenEquipping_ValidEquipment_CorrectSlotIsUpdated()
        {
            _mario.Equip(Hammer);

            _mario.Loadout.Weapon.Should().Be(Hammer);
        }

        [Fact]
        public void WhenEquipping_ValidEquipment_EffectiveStatsAreUpdated()
        {
            _mario.Equip(Hammer);

            _mario.EffectiveStatistics.Should().Be(_mario.Statistics + Hammer.Statistics);
        }

        #endregion
    }
}
