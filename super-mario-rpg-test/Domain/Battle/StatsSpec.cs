using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Battle;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class StatsSpec : ValueObjectSpec<Stats>
    {
        #region Protected Interface

        protected override ValueObject<Stats> CreateValueObject() => new Stats(20, 0, 20, 10, 2, 20);

        #endregion
    }
}
