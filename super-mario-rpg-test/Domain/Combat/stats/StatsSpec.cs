using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Combat;
using Xunit;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public class StatsSpec : ValueObjectSpec<Stats>
    {
        #region Test Methods

        protected override ValueObject<Stats> CreateValueObject() => CreateStats(20, 0, 20, 10, 2, 20);

        [Fact]
        public void WhenAdding_EachStatIsSummed()
        {
            var addend1 = CreateStats(20, 0, 20, 10, 2, 20);
            var addend2 = CreateStats(1, 2, 3, 4, 5, 6);

            var sum = addend1 + addend2;

            sum.Attack.Value.Should().Be(21);
            sum.Defense.Value.Should().Be(2);
            sum.Hp.Value.Should().Be(23);
            sum.SpecialAttack.Value.Should().Be(14);
            sum.SpecialDefense.Value.Should().Be(7);
            sum.Speed.Value.Should().Be(26);
        }

        #endregion
    }
}
