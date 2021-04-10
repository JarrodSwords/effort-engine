namespace SuperMarioRpg.Api
{
    public record CreateEnemyArgs(
        string Name,
        ushort HitPoints,
        short Attack,
        short Defense,
        short MagicAttack,
        short MagicDefense,
        short Speed,
        short Evade,
        short MagicEvade
    );
}
