namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyBuilder : ICharacterBuilder
    {
        EnemyStatistics GetCombatStats();
    }
}
