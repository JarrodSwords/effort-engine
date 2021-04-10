using System;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.Domain.Test
{
    public class NonPlayerCharacterSpec : CharacterSpec
    {
        #region Core

        private const string Toad = "Toad";
        private readonly FluentCharacterBuilder _builder = new();

        #endregion

        #region Test Methods

        protected override NonPlayerCharacter CreateEntity()
        {
            return _builder.WithName(Toad).BuildNonPlayerCharacter();
        }

        protected override NonPlayerCharacter CreateEntity(Guid id)
        {
            return _builder.WithId(id).BuildNonPlayerCharacter();
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
