using System;
using FluentAssertions;
using SuperMarioRpg.Api;
using Xunit;

namespace SuperMarioRpg.Domain.Test
{
    public class NonPlayerCharacterSpec : CharacterSpec
    {
        #region Core

        private const string Toad = "Toad";
        private readonly NonPlayerCharacterBuilder _builder = new();
        private readonly FluentCharacterBuilder _fluentBuilder = new();
        private readonly CreateNonPlayerCharacterArgs _toad = new(Toad);

        #endregion

        #region Test Methods

        protected override NonPlayerCharacter CreateEntity()
        {
            return _builder.From(_toad).Build();
        }

        protected override NonPlayerCharacter CreateEntity(Guid id)
        {
            return _fluentBuilder.WithId(id).BuildNonPlayerCharacter();
        }

        [Fact]
        public void WhenInstantiating()
        {
            var character = CreateEntity();

            character.Name.Value.Should().Be(_toad.Name);
        }

        #endregion
    }
}
