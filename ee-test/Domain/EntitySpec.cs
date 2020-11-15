using System;
using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class EntitySpec
    {
        #region Protected Interface

        protected abstract Entity CreateEntity();
        protected abstract Entity CreateEntity(Guid id);

        #endregion

        #region Test Methods

        [Fact]
        public void CreatedWithId_HasCorrectId()
        {
            var id = Guid.NewGuid();
            var entity = CreateEntity(id);

            entity.Id.Value.Should().Be(id);
        }

        [Fact]
        public void CreatedWithoutId_CreatesId()
        {
            var entity = CreateEntity();

            entity.Id.Value.Should().NotBeEmpty();
        }

        [Fact]
        public void HasIdentifierEquality()
        {
            var id = Guid.NewGuid();
            var entity1 = CreateEntity(id);
            var entity2 = CreateEntity(id);

            entity2.Should().NotBeSameAs(entity1);
            entity2.Should().BeEquivalentTo(entity1, o => o.RespectingRuntimeTypes());
        }

        [Fact]
        public void HasReferenceEquality()
        {
            var entity1 = CreateEntity();
            var entity2 = entity1;

            entity2.Should().BeSameAs(entity1);
        }

        #endregion
    }
}
