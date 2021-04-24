using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Test
{
    public class NonPlayerCharacterSpec : CharacterSpec
    {
        #region Core

        private const string Toad = "Toad";
        private readonly FluentBuilder _builder = new();

        #endregion

        #region Test Methods

        protected override NonPlayableCharacter CreateEntity()
        {
            return _builder.WithName(Toad).BuildNonPlayerCharacter();
        }

        protected override NonPlayableCharacter CreateEntity(Guid id)
        {
            return _builder.WithId(id).BuildNonPlayerCharacter();
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
