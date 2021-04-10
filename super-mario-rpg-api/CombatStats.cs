namespace SuperMarioRpg.Api
{
    public record CombatStats(
        ushort HitPoints,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade,
        short Speed
    );
}
