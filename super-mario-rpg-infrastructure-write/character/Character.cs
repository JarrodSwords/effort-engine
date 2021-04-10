using System;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Character : Entity
    {
        #region Public Interface

        public CombatStats CombatStats { get; set; }
        public Guid? CombatStatsId { get; set; }
        public string Name { get; set; }

        public static Character From(Enemy enemy)
        {
            var (hitPoints, attack, magicAttack, defense, magicDefense, evade, magicEvade, speed) = enemy.CombatStats;

            return new()
            {
                Name = enemy.Name.Value,
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
                Id = nonPlayerCharacter.Id.Value,
                Name = nonPlayerCharacter.Name.Value
            };
        }

        #endregion
    }
}
