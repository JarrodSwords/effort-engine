using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Battle;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class StatSpec : TinyTypeSpec<short>
    {
        #region Protected Interface

        protected override TinyType<short> CreateTinyType(short value) => new Stat(value);
        protected override short CreateValue() => 10;

        #endregion
    }
}
