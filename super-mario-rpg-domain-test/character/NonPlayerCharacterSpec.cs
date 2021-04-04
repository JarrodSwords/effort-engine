using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Test
{
    public class NonPlayerCharacterSpec : CharacterSpec
    {
        #region Core

        private const string Toad = "Toad";

        #endregion

        #region Test Methods

        protected override NonPlayerCharacter CreateEntity()
        {
            return new(Toad);
        }

        protected override NonPlayerCharacter CreateEntity(Guid id)
        {
            return new(Toad, id);
        }

        [Fact]
        public void WhenInstantiating()
        {
            var character = CreateEntity();

            character.Name.Value.Should().Be(Toad);
        }

        #endregion
    }
}
