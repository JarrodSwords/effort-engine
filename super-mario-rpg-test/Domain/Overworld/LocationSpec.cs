using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Test.Domain.Overworld
{
    public class LocationSpec : ValueObjectSpec<Location>
    {
        #region Protected Interface

        protected override ValueObject<Location> CreateValueObject() => new Location("Mario's Pad");

        #endregion
    }
}
