using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class StatSpec : TinyTypeSpec<short>
    {
        #region Test Methods

        protected override TinyType<short> CreateTinyType(short value) => Stat.Create(value);
        protected override short CreateValue() => 10;

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(10, -2, 8)]
        public void WhenAdding_InBounds_SumIsExpectedValue(short value1, short value2, short expectedValue)
        {
            var addend1 = Stat.Create(value1);
            var addend2 = Stat.Create(value2);

            var sum = addend1 + addend2;

            sum.Value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(Stat.Max, 1)]
        [InlineData(Stat.Min, -1)]
        public void WhenAdding_OutOfBounds_SumIsClamped(short limit, short addend)
        {
            var addend1 = Stat.Create(limit);
            var addend2 = Stat.Create(addend);

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
                var stat = Stat.Create((short) (limit + addend));
            };

            createInvalidStat.Should().Throw<ValidationException>();
        }

        #endregion
    }
}
