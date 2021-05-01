namespace SuperMarioRpg.Domain.Stats
{
    public interface ICombatStatsBuilder
    {
        short GetAttack();
        short GetDefense();
        ushort GetHitPoints();
        short GetMagicAttack();
        short GetMagicDefense();
        short GetSpeed();
    }
}
