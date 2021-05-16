namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyBuilder : ICharacterBuilder
    {
        EnemyCombatStats GetCombatStats();
    }
}
