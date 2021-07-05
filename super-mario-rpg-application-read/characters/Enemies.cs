using System.Collections.Generic;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FetchEnemies : IQuery<IEnumerable<Enemy>>;

    public record FindEnemy(string Name) : IQuery<Enemy>;

    public record Enemy(
        string Name,
        EnemyCombatStats BaseStats
    );

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
