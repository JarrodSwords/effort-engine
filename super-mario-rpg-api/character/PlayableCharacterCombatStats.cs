namespace SuperMarioRpg.Api
{
    public record PlayableCharacterCombatStats(
        ushort HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    );
}
