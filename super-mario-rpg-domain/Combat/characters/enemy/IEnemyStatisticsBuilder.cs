namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyStatisticsBuilder : IStatisticsBuilder
    {
        Evade GetEvade();
        FlowerPoints GetFlowerPoints();
        MagicEvade GetMagicEvade();
    }
}
