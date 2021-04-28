namespace SuperMarioRpg.Domain.Stats
{
    public interface IEnemyCombatStatsBuilder : ICombatStatsBuilder
    {
        decimal GetEvade();
        byte GetFlowerPoints();
        decimal GetMagicEvade();
    }
}
