using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class ValueObjectSpec
    {
        #region Protected Interface

        protected abstract ValueObject CreateValueObject();

        #endregion

        #region Test Methods

        [Fact]
        public void HasReferenceEquality()
        {
            var valueObject1 = CreateValueObject();
            var valueObject2 = valueObject1;

            valueObject2.Should().Be(valueObject1);
        }

        [Fact]
        public void HasStructureEquality()
        {
            var valueObject1 = CreateValueObject();
            var valueObject2 = CreateValueObject();

            valueObject2.Should().BeEquivalentTo(valueObject1);
        }

        #endregion
    }
}
