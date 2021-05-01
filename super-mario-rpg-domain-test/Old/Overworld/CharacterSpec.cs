using FluentAssertions;
using SuperMarioRpg.Domain.Old.Overworld;
using Xunit;

namespace SuperMarioRpg.Domain.Test.Old.Overworld
{
    public class CharacterSpec
    {
        #region Test Methods

        [Fact]
        public void CanMoveToLocation()
        {
            var character = new Character();
            var location = new Location("Mario's Pad");

            character.Move(location);

            character.Location.Should().Be(location);
        }

        #endregion
    }
}
