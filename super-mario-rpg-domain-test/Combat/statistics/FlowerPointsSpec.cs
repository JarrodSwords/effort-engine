using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class FlowerPointsSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject Create() => new FlowerPoints(1);
        protected override ValueObject CreateOther() => new FlowerPoints(2);

        #endregion
    }
}
