namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyCombatStatsBuilder : ICombatStatsBuilder
    {
        decimal GetEvade();
        byte GetFlowerPoints();
        decimal GetMagicEvade();
    }
}
