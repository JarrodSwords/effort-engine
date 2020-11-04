using System;
using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class EntityBaseTest
    {
        #region Test Methods

        protected abstract Entity CreateDifferentEntity(Guid id);
        protected abstract Entity CreateEntity(Guid id);
        protected abstract Entity CreateEntity();

        [Fact]
        public void EntitiesHaveIdentifierEquality()
        {
            var id = Guid.NewGuid();
            var entity1 = CreateEntity(id);
            var entity2 = CreateDifferentEntity(id);

            entity2.Should().NotBeSameAs(entity1);
            entity2.Should().BeEquivalentTo(entity1, o => o.RespectingRuntimeTypes());
        }

        [Fact]
        public void EntitiesHaveReferenceEquality()
        {
            var entity1 = CreateEntity();
            var entity2 = entity1;

            entity2.Should().BeSameAs(entity1);
        }

        [Fact]
        public void WhenCreatingEntity_WithId_EntityHasCorrectId()
        {
            var id = Guid.NewGuid();
            var entity = CreateEntity(id);

            entity.Id.Value.Should().Be(id);
        }

        [Fact]
        public void WhenCreatingEntity_WithoutId_EntityHasId()
        {
            var entity = CreateEntity();

            entity.Id.Value.Should().NotBeEmpty();
        }

        #endregion
    }
}
