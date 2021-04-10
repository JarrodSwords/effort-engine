using System;

namespace SuperMarioRpg.Api
{
    public record CharacterDto(
        Guid Id = default,
        string Name = default,
        CombatStats CombatStats = default
    );
}
