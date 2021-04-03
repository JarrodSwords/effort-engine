using System;

namespace SuperMarioRpg.Application.Read
{
    public record CharacterDto(
        Guid Id,
        string Name,
        CombatStatsDto CombatStats
    );

    public record CombatStatsDto(
        byte Attack,
        byte Defense,
        ushort HitPoints,
        byte MagicAttack,
        byte MagicDefense,
        byte Speed
    );
}
