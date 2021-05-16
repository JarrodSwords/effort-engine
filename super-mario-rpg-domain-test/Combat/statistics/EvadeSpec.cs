using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class EvadeSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Evade(1);
        protected override ValueObject CreateOther() => new Evade(2);

        #endregion
    }
}
