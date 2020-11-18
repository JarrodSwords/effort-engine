using Effort.Domain;
using FluentAssertions;
using Xunit;
using static Effort.Domain.Name;

namespace Effort.Test.Domain
{
    public class NameSpec : TinyTypeSpec<string>
    {
        #region Test Methods

        protected override TinyType<string> CreateTinyType(string value) => CreateName(value);
        protected override string CreateValue() => "Mario's Pad";

        [Theory]
        [InlineData("name", "NAME")]
        [InlineData("Name", "nAME")]
        public void IsCaseInsensitive(string value1, string value2)
        {
            var name1 = CreateName(value1);
            var name2 = CreateName(value2);

            name2.Should().BeEquivalentTo(name1);
        }

        #endregion
    }
}
