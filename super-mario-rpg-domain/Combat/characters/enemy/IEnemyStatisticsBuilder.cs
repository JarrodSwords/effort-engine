namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyStatisticsBuilder : IStatisticsBuilder
    {
        decimal GetEvade();
        byte GetFlowerPoints();
        decimal GetMagicEvade();
    }
}
