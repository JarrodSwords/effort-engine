using System;
using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class EntityBaseTest
    {
        #region Test Methods

        protected abstract Entity CreateEntity(Guid id);
        protected abstract Entity CreateEntity();

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

            entity.Id.Should().NotBeNull();
            entity.Id.Value.Should().NotBeEmpty();
        }

        #endregion
    }
}
