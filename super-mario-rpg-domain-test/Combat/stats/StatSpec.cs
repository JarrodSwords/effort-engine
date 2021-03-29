using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using FluentValidation;
using Xunit;
using static SuperMarioRpg.Domain.Combat.Stat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class StatSpec : TinyTypeSpec<short>
    {
        #region Test Methods

        protected override TinyType<short> CreateTinyType(short value)
        {
            return CreateStat(value);
        }

        protected override short CreateValue()
        {
            return 10;
        }

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(10, -2, 8)]
        public void WhenAdding_InBounds_SumIsExpectedValue(short value1, short value2, short expectedValue)
        {
            var addend1 = CreateStat(value1);
            var addend2 = CreateStat(value2);

            var sum = addend1 + addend2;

            sum.Value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(Max, 1)]
        [InlineData(Min, -1)]
        public void WhenAdding_OutOfBounds_SumIsClamped(short limit, short addend)
        {
            var addend1 = CreateStat(limit);
            var addend2 = CreateStat(addend);

            var sum = addend1 + addend2;

            sum.Value.Should().Be(limit);
        }

        [Theory]
        [InlineData(Max, 1)]
        [InlineData(Min, -1)]
        public void WhenInstantiating_WithValueOutOfRange_ExceptionIsThrown(short limit, short addend)
        {
            Action createInvalidStat = () => { CreateStat((short) (limit + addend)); };

            createInvalidStat.Should().Throw<ValidationException>();
        }

        #endregion
    }
}
