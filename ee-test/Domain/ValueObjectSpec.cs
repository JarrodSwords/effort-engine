using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class ValueObjectSpec<T>
        where T : ValueObject<T>
    {
        #region Protected Interface

        protected abstract ValueObject<T> CreateValueObject();

        #endregion

        #region Test Methods

        [Fact]
        public void HasReferenceEquality()
        {
            var valueObject1 = CreateValueObject();
            var valueObject2 = valueObject1;

            valueObject2.Should().Be(valueObject1);
        }

        #endregion
    }
}
