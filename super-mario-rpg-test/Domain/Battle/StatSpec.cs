using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class StatSpec : TinyTypeSpec<short>
    {
        #region Test Methods

        [Theory]
        [InlineData(-256)]
        [InlineData(256)]
        public void CannotExceedBounds(short value)
        {
            Action createInvalidStat = () =>
            {
                var stat = new Stat(value);
            };

            createInvalidStat.Should().Throw<ArgumentOutOfRangeException>();
        }

        protected override TinyType<short> CreateTinyType(short value) => new Stat(value);
        protected override short CreateValue() => 10;

        #endregion
    }
}
