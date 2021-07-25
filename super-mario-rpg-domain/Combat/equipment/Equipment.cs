using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Equipment : AggregateRoot
    {
        #region Creation

        public Equipment(Id id) : base(id)
        {
        }

        #endregion
    }
}
