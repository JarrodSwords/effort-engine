using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public interface IEnemyBuilder : ICharacterBuilder
    {
        EnemyCombatStats GetCombatStats();
    }
}
