namespace SuperMarioRpg.Api
{
    public record PlayableCharacter(
        string Name,
        PlayableCharacterCombatStats BaseStats
    );
}
