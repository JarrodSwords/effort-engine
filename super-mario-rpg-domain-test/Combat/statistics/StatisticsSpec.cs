using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class StatisticsSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Statistics(1, 2, 3, 4, 5);
        protected override ValueObject CreateOther() => new Statistics(2, 3, 4, 5, 6);

        #endregion
    }
}
