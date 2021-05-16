namespace SuperMarioRpg.Domain.Combat
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
