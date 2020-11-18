using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.Level;
using static SuperMarioRpg.Domain.Combat.Xp;

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
        public void WhenDistributingXp_CharacterIsUpdated(ushort xpValue, byte expectedLevel)
        {
            var xp = CreateXp(xpValue);

            _service.DistributeXp(xp, _character);

            _character.Level.Should().Be(CreateLevel(expectedLevel));
            _character.Xp.Should().Be(xp);
        }

        #endregion
    }
}
