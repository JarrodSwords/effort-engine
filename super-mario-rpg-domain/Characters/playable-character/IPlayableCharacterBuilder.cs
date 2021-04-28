using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public interface IPlayableCharacterBuilder : ICharacterBuilder
    {
        CombatStats GetCombatStats();
    }
}
