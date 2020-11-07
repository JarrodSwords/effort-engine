using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public class NameSpec : TinyTypeSpec<string>
    {
        #region Test Methods

        protected override TinyType<string> CreateTinyType(string value) => new Name(value);
        protected override string CreateValue() => "Mario's Pad";

        [Theory]
        [InlineData("name", "NAME")]
        [InlineData("Name", "nAME")]
        public void IsCaseInsensitive(string value1, string value2)
        {
            var name1 = CreateTinyType(value1);
            var name2 = CreateTinyType(value2);

            name2.Should().BeEquivalentTo(name1);
        }

        #endregion
    }
}
