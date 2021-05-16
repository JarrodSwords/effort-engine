namespace SuperMarioRpg.Domain
{
    public interface IStatisticsBuilder
    {
        Attack GetAttack();
        Defense GetDefense();
        HitPoints GetHitPoints();
        MagicAttack GetMagicAttack();
        MagicDefense GetMagicDefense();
        Speed GetSpeed();
    }
}
