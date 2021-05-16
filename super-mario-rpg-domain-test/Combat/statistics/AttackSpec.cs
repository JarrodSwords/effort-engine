using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class AttackSpec : StatisticSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Attack(1);
        protected override ValueObject CreateOther() => new Attack(2);

        #endregion
    }
}
