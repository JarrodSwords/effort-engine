using Effort.Domain;
using Effort.Domain.Test;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class AttackSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Attack(1);
        protected override ValueObject CreateOther() => new Attack(2);

        #endregion
    }
}
