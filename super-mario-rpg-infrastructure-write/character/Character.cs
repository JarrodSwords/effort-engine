using System;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Character : Entity
    {
        #region Public Interface

        public CombatStats CombatStats { get; set; }
        public Guid? CombatStatsId { get; set; }
        public bool IsEnemy { get; set; }
        public bool IsNonPlayerCharacter { get; set; }
        public string Name { get; set; }

        public static Character From(Enemy enemy)
        {
            var (hitPoints, attack, magicAttack, defense, magicDefense, evade, magicEvade, speed) = enemy.CombatStats;

            return new()
            {
                Name = enemy.Name.Value,
                IsEnemy = enemy.CharacterTypes.Contains(CharacterTypes.Enemy),
                IsNonPlayerCharacter = enemy.CharacterTypes.Contains(CharacterTypes.NonPlayerCharacter),
                CombatStats = new CombatStats(
                    hitPoints,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense,
                    evade,
                    magicEvade,
                    speed
                )
            };
        }

        public static Character From(NonPlayerCharacter nonPlayerCharacter)
        {
            return new()
            {
                Name = nonPlayerCharacter.Name.Value,
                IsEnemy = nonPlayerCharacter.CharacterTypes.Contains(CharacterTypes.Enemy),
                IsNonPlayerCharacter = nonPlayerCharacter.CharacterTypes.Contains(CharacterTypes.NonPlayerCharacter)
            };
        }

        #endregion
    }
}
