using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Test.Domain.Overworld
{
    public class RegionSpec : ValueObjectSpec
    {
        #region Protected Interface

        protected override ValueObject CreateValueObject() => new Region("Mushroom Kingdom");

        #endregion
    }
}
