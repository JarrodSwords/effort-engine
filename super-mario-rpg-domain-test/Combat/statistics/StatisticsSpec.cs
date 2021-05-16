using Effort.Domain;
using Effort.Domain.Test;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class StatisticsSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new StatisticsDto(1, 2, 3, 4, 5, 6);
        protected override ValueObject CreateOther() => new StatisticsDto(2, 3, 4, 5, 6, 7);

        #endregion
    }
}
