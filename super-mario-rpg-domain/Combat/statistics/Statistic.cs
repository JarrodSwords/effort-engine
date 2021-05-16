using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class Statistic : TinyType<short>
    {
        #region Creation

        protected Statistic(short value) : base(value)
        {
        }

        #endregion
    }
}
