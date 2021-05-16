using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class MagicDefenseSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new MagicDefense(1);
        protected override ValueObject CreateOther() => new MagicDefense(2);

        #endregion
    }
}
