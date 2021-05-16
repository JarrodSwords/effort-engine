namespace SuperMarioRpg.Domain.Combat
{
    public class EnemyStatistics : Statistics
    {
        #region Creation

        public EnemyStatistics(IEnemyStatisticsBuilder builder) : base(builder)
        {
            Evade = builder.GetEvade();
            FlowerPoints = builder.GetFlowerPoints();
            MagicEvade = builder.GetMagicEvade();
        }

        #endregion

        #region Public Interface

        public decimal Evade { get; }
        public byte FlowerPoints { get; }
        public decimal MagicEvade { get; }

        #endregion
    }
}
