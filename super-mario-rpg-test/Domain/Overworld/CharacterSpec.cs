using FluentAssertions;
using SuperMarioRpg.Domain.Overworld;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Overworld
{
    public class CharacterSpec
    {
        #region Test Methods

        [Fact]
        public void CharacterCanMoveToLocation()
        {
            var character = new Character();
            var location = new Location();

            character.Move(location);

            character.Location.Should().Be(location);
        }

        #endregion
    }
}
