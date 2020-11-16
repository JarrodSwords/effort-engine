using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
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
        [InlineData(10, 2, 12)]
        [InlineData(10, -2, 8)]
        public void WhenAdding_InBounds_SumIsExpectedValue(short value1, short value2, short expectedValue)
        {
            var addend1 = new Stat(value1);
            var addend2 = new Stat(value2);

            var sum = addend1 + addend2;

            sum.Value.Should().Be(expectedValue);
        }

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
        public void WhenInstantiating_WithValueOutOfRange_ExceptionIsThrown(short limit, short addend)
        {
            Action createInvalidStat = () =>
            {
                var stat = new Stat((short) (limit + addend));
            };

            createInvalidStat.Should().Throw<ValidationException>();
        }

        #endregion
    }
}
