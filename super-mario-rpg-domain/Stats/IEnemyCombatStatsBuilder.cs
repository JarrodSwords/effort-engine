namespace SuperMarioRpg.Domain.Stats
{
    public interface IEnemyCombatStatsBuilder : ICombatStatsBuilder
    {
        #region Public Interface

        decimal GetEvade();
        byte GetFlowerPoints();
        decimal GetMagicEvade();

        #endregion
    }
}
