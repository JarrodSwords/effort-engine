using FluentAssertions;
using Xunit;

namespace Effort.Domain.Test
{
    public abstract class TinyTypeSpec<T>
    {
        #region Protected Interface

        protected abstract TinyType<T> CreateTinyType(T value);
        protected abstract T CreateValue();

        #endregion

        #region Test Methods

        [Fact]
        public void HasReferenceEquality()
        {
            var tinyType1 = CreateTinyType(CreateValue());
            var tinyType2 = tinyType1;

            tinyType2.Should().BeSameAs(tinyType1);
        }

        [Fact]
        public void HasStructureEquality()
        {
            var value = CreateValue();
            var tinyType1 = CreateTinyType(value);
            var tinyType2 = CreateTinyType(value);

            tinyType2.Should().NotBeSameAs(tinyType1);
            tinyType2.Should().BeEquivalentTo(tinyType1);
        }

        #endregion
    }
}
