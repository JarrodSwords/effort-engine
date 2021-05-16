using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class MagicEvadeSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new MagicEvade(1);
        protected override ValueObject CreateOther() => new MagicEvade(2);

        #endregion
    }
}
