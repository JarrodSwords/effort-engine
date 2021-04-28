namespace SuperMarioRpg.Domain.Characters
{
    public partial class Enemy
    {
        public record CombatStats(
            ushort HitPoints,
            byte FlowerPoints,
            short Speed,
            short Attack,
            short MagicAttack,
            short Defense,
            short MagicDefense,
            decimal Evade,
            decimal MagicEvade
        );
    }
}
