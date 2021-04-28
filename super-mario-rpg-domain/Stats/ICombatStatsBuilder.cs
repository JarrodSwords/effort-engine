namespace SuperMarioRpg.Domain.Stats
{
    public interface ICombatStatsBuilder
    {
        #region Public Interface

        short GetAttack();
        short GetDefense();
        ushort GetHitPoints();
        short GetMagicAttack();
        short GetMagicDefense();
        short GetSpeed();

        #endregion
    }
}
