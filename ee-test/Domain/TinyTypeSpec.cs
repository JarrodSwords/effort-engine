using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public abstract class TinyTypeSpec<T>
    {
        #region Protected Interface

        protected abstract TinyType<T> CreateTinyType();

        #endregion

        #region Test Methods

        [Fact]
        public void HasReferenceEquality()
        {
            var tinyType1 = CreateTinyType();
            var tinyType2 = tinyType1;

            tinyType2.Should().BeSameAs(tinyType1);
        }

        #endregion
    }
}
