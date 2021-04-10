using System;

namespace SuperMarioRpg.Api
{
    public record CharacterDto(
        Guid Id = default,
        string Name = default,
        CombatStatsDto CombatStats = default
    );
}
