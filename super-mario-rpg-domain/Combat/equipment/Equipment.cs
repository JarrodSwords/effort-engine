using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Equipment : AggregateRoot
    {
        #region Creation

        public Equipment(
            Id id = default,
            Statistics statistics = default
        ) : base(id)
        {
            Statistics = statistics;
        }

        #endregion

        #region Public Interface

        public Statistics Statistics { get; set; }

        #endregion
    }
}
