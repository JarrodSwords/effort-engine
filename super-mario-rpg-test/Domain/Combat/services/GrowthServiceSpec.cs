using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class GrowthServiceSpec
    {
        #region Core

        private readonly Character _character;
        private readonly GrowthService _service;

        public GrowthServiceSpec()
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            _character = builder.Build();
            _service = new GrowthService();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenGainingExperience_ExperienceIsExpected()
        {
            _service.DistributeExperience(new ExperiencePoints(50), _character);

            _character.ExperiencePoints.Value.Should().Be(50);
        }

        [Theory]
        [InlineData(15, 1)]
        [InlineData(16, 2)]
        [InlineData(50, 3)]
        public void WhenGainingExperience_LevelChanges(ushort experiencePoints, byte expectedLevel)
        {
            _service.DistributeExperience(new ExperiencePoints(experiencePoints), _character);

            _character.Level.Should().Be(new Level(expectedLevel));
        }

        #endregion
    }
}
