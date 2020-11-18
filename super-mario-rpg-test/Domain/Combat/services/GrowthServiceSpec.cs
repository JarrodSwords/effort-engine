using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class GrowthServiceSpec
    {
        #region Test Methods

        [Theory]
        [InlineData(15, 0)]
        [InlineData(16, 1)]
        [InlineData(50, 2)]
        public void WhenGainingExperience_LevelChanges(ushort experiencePoints, byte levelsGained)
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            var character = builder.Build();

            var expectedLevel = character.Level + new Level(levelsGained);

            var service = new GrowthService();
            service.DistributeExperience(new ExperiencePoints(experiencePoints), character);

            character.Level.Should().Be(expectedLevel);
        }

        #endregion
    }
}
