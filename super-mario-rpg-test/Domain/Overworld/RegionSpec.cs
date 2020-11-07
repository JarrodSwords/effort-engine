using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Test.Domain.Overworld
{
    public class RegionSpec : ValueObjectSpec<Region>
    {
        #region Protected Interface

        protected override ValueObject<Region> CreateValueObject() => new Region("Mushroom Kingdom");

        #endregion
    }
}