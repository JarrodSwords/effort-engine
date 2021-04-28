using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Domain.Characters
{
    public interface ICharacterBuilder
    {
        CharacterTypes GetCharacterTypes();
        CombatStats GetCombatStats();
        EnemyCombatStats GetEnemyCombatStats();
        Id GetId();
        Name GetName();
    }
}
