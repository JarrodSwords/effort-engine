namespace SuperMarioRpg.Domain
{
    public partial class PlayableCharacter
    {
        public record CombatStats(
            ushort HitPoints,
            short Speed,
            short Attack,
            short MagicAttack,
            short Defense,
            short MagicDefense
        );
    }
}
