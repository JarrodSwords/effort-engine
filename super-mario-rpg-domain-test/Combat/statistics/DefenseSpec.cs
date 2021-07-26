using Effort.Domain;
using Effort.Domain.Test;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class DefenseSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Defense(1);
        protected override ValueObject CreateOther() => new Defense(2);

        #endregion
    }
}
