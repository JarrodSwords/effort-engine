using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class SpeedSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new Speed(1);
        protected override ValueObject CreateOther() => new Speed(2);

        #endregion
    }
}
