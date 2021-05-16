using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class DefenseSpec : StatisticSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Defense(1);
        protected override ValueObject CreateOther() => new Defense(2);

        #endregion
    }
}
