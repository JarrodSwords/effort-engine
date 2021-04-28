using System;
using FluentAssertions;
using SuperMarioRpg.Domain.Characters;
using Xunit;

namespace SuperMarioRpg.Domain.Test.Configuration
{
    public class NonPlayerCharacterSpec : CharacterSpec
    {
        #region Core

        private const string Toad = "Toad";
        private readonly FluentCharacterBuilder _characterBuilder = new();

        #endregion

        #region Test Methods

        protected override NonPlayableCharacter CreateEntity()
        {
            return _characterBuilder.WithName(Toad).BuildNonPlayerCharacter();
        }

        protected override NonPlayableCharacter CreateEntity(Guid id)
        {
            return _characterBuilder.WithId(id).BuildNonPlayerCharacter();
        }

        [Fact]
        public void WhenInstantiating()
        {
            var character = CreateEntity();

            character.Name.Should().Be(Toad);
        }

        #endregion
    }
}
