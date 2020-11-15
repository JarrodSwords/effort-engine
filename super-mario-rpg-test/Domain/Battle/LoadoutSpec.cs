using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Battle;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class LoadoutSpec : ValueObjectSpec<Loadout>
    {
        #region Protected Interface

        protected override ValueObject<Loadout> CreateValueObject() => new Loadout();

        #endregion
    }
}
