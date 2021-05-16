namespace SuperMarioRpg.Domain.Combat
{
    public class Enemy : Character
    {
        #region Creation

        public Enemy(IEnemyBuilder builder) : base(builder)
        {
            Statistics = builder.GetStatistics();
        }

        #endregion

        #region Public Interface

        public Statistics Statistics { get; }

        #endregion
    }
}
