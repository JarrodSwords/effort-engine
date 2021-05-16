using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class MagicDefenseSpec : StatisticSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new MagicDefense(1);
        protected override ValueObject CreateOther() => new MagicDefense(2);

        #endregion
    }
}
