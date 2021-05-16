namespace SuperMarioRpg.Domain.Combat
{
    public interface IPlayableCharacterBuilder : ICharacterBuilder
    {
        CombatStats GetCombatStats();
    }
}
