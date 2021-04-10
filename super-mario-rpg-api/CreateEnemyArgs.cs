namespace SuperMarioRpg.Api
{
    public record CreateEnemyArgs(
        string Name,
        ushort HitPoints,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        short Evade,
        short MagicEvade,
        short Speed
    );
}
