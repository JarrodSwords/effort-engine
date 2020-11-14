using Effort.Domain;
using FluentAssertions;
using Xunit;

namespace Effort.Test.Domain
{
    public class NameSpec : TinyTypeSpec<string>
    {
        #region Test Methods

        protected override TinyType<string> CreateTinyType(string value) => Name.Create(value);
        protected override string CreateValue() => "Mario's Pad";

        [Theory]
        [InlineData("name", "NAME")]
        [InlineData("Name", "nAME")]
        public void IsCaseInsensitive(string value1, string value2)
        {
            var name1 = Name.Create(value1);
            var name2 = Name.Create(value2);

            name2.Should().BeEquivalentTo(name1);
        }

        #endregion
    }
}
