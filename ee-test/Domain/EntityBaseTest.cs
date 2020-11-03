using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class EntityBaseTest
    {
        #region Test Methods

        protected abstract Entity CreateEntity();

        [Fact]
        public void WhenCreatingEntity_WithoutId_EntityHasId()
        {
            var entity = CreateEntity();

            entity.Id.Should().NotBeEmpty();
        }

        #endregion
    }
}
