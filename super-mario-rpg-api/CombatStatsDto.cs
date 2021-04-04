namespace SuperMarioRpg.Api
{
    public record CombatStatsDto(
        byte Attack,
        byte Defense,
        ushort HitPoints,
        byte MagicAttack,
        byte MagicDefense,
        byte Speed
    );
}
