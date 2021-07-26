using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Equipment : AggregateRoot
    {
        public static Equipment Hammer = new(statistics: new Statistics(10, 0, 0, 0, 0, 0));

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
