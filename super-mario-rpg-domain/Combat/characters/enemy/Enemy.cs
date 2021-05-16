namespace SuperMarioRpg.Domain.Combat
{
    public class Enemy : Character
    {
        #region Creation

        public Enemy(IEnemyBuilder builder) : base(builder)
        {
            BaseStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public EnemyStatistics BaseStats { get; }

        #endregion
    }
}
