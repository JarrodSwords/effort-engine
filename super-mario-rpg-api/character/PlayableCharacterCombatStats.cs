namespace SuperMarioRpg.Api
{
    public record PlayableCharacterCombatStats(
        short HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    );
}
