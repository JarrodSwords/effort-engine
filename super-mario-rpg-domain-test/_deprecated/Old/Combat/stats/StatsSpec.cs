using FluentAssertions;
using Xunit;
using static SuperMarioRpg.Domain.Old.Combat.Stats;

namespace SuperMarioRpg.Domain.Test.Old.Combat
{
    public class StatsSpec
    {
        #region Test Methods

        [Fact]
        public void WhenAdding_EachStatIsSummed()
        {
            var addend1 = CreateStats(20, 0, 20, 10, 2, 20);
            var addend2 = CreateStats(1, 2, 3, 4, 5, 6);

            var sum = addend1 + addend2;

            sum.Attack.Should().Be((short) 21);
            sum.Defense.Should().Be((short) 2);
            sum.Hp.Should().Be((short) 23);
            sum.SpecialAttack.Should().Be((short) 14);
            sum.SpecialDefense.Should().Be((short) 7);
            sum.Speed.Should().Be((short) 26);
        }

        #endregion
    }
}
