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

        [Theory]
        [InlineData(15, 1)]
        [InlineData(16, 2)]
        [InlineData(50, 3)]
        public void WhenDistributingXp_CharacterIsUpdated(ushort xp, byte expectedLevel)
        {
            _service.DistributeXp(Xp.Create(xp), _character);

            _character.Level.Should().Be(Level.Create(expectedLevel));
            _character.Xp.Value.Should().Be(xp);
        }

        #endregion
    }
}
