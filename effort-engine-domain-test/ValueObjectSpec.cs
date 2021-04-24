using FluentAssertions;
using Xunit;

namespace Effort.Domain.Test
{
    public abstract class ValueObjectSpec
    {
        #region Protected Interface

        protected abstract ValueObject Create();

        #endregion

        #region Test Methods

        [Fact]
        public void HasStructuralEquality()
        {
            var instance1 = Create();
            var instance2 = Create();

            instance2.Should().NotBeSameAs(instance1);
            instance2.Should().Be(instance1);
        }

        #endregion
    }
}
