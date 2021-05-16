namespace SuperMarioRpg.Domain.Combat
{
    public class EnemyCombatStats : CombatStats
    {
        #region Creation

        public EnemyCombatStats(IEnemyCombatStatsBuilder builder) : base(builder)
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
