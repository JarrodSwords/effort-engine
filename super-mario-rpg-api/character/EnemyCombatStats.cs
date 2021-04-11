namespace SuperMarioRpg.Api
{
    public record EnemyCombatStats(
        ushort HitPoints,
        byte? FlowerPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal? Evade,
        decimal? MagicEvade
    );
}
