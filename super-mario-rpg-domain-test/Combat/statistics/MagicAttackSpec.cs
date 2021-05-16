using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class MagicAttackSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new MagicAttack(1);
        protected override ValueObject CreateOther() => new MagicAttack(2);

        #endregion
    }
}
