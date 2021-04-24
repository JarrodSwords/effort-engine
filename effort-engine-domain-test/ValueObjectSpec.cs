using FluentAssertions;
using Xunit;

namespace Effort.Domain.Test
{
    public abstract class ValueObjectSpec
    {
        #region Protected Interface

        protected abstract ValueObject Create();
        protected abstract ValueObject CreateOther();

        #endregion

        #region Test Methods

        [Fact]
        public void HasReferenceEquality()
        {
            var instance1 = Create();
            var instance2 = instance1;

            instance2.Should().BeSameAs(instance1);
            instance2.Should().Be(instance1);
        }

        [Fact]
        public void HasStructuralEquality()
        {
            var instance1 = Create();
            var instance2 = Create();

            instance2.Should().NotBeSameAs(instance1);
            instance2.Should().Be(instance1);
        }

        [Fact]
        public void HasStructuralInequality()
        {
            var instance1 = Create();
            var instance2 = CreateOther();

            instance2.Should().NotBe(instance1);
        }

        #endregion
    }
}
