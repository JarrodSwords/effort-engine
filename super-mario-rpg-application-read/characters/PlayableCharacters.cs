using System.Collections.Generic;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FetchPlayableCharacters : IQuery<IEnumerable<PlayableCharacter>>;

    public record FindPlayableCharacter(string Name) : IQuery<PlayableCharacter>;

    public record PlayableCharacter(
        string Name,
        PlayableCharacterCombatStats BaseStats
    );

    public record PlayableCharacterCombatStats(
        short HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    );
}
