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

        protected override TinyType<short> CreateTinyType(short value) => new Stat(value);
        protected override short CreateValue() => 10;

        [Theory]
        [InlineData(Stat.Max, 1)]
        [InlineData(Stat.Min, -1)]
        public void WhenAdding_OutOfBounds_SumIsClamped(short limit, short addend)
        {
            var addend1 = new Stat(limit);
            var addend2 = new Stat(addend);

            var sum = addend1 + addend2;

            sum.Value.Should().Be(limit);
        }

        [Theory]
        [InlineData(Stat.Max, 1)]
        [InlineData(Stat.Min, -1)]
        public void WhenInstantiating_WithValueOutOfRange_ThrowException(short limit, short addend)
        {
            Action createInvalidStat = () =>
            {
                var stat = new Stat((short) (limit + addend));
            };

            createInvalidStat.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}
