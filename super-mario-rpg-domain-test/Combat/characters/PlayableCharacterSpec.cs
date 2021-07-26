using System;
using Effort.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayableCharacterSpec : CharacterSpec
    {
        #region Core

        private readonly MarioBuilder _marioBuilder = new();

        #endregion

        #region Test Methods

        protected override Entity CreateEntity() => _marioBuilder;
        protected override Entity CreateEntity(Guid id) => _marioBuilder.With(id);

        [Fact]
        public void WhenEquipping_ValidEquipment_EffectiveStatsAreUpdated()
        {
            var mario = new PlayableCharacter(_marioBuilder);
            var hammer = new Equipment(
                null,
                new Statistics(1, 2, 3, 4, 5, 6)
            );

            mario.Equip(hammer);

            mario.EffectiveStatistics.Should().Be(mario.Statistics + hammer.Statistics);
        }

        #endregion
    }
}
