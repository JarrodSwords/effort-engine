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

        public static Character From(Domain.Character character)
        {
            return new()
            {
                Id = character.Id.Value,
                Name = character.Name.Value
            };
        }

        public static Character From(Enemy enemy)
        {
            var stats = enemy.CombatStats.Stats;

            return new()
            {
                Name = enemy.Name.Value,
                CombatStats = new CombatStats(
                    stats.Attack.Value,
                    stats.Defense.Value,
                    stats.Evade.Value,
                    (ushort) stats.Hp.Value,
                    stats.SpecialAttack.Value,
                    stats.SpecialDefense.Value,
                    stats.MagicEvade.Value,
                    stats.Speed.Value
                )
            };
        }

        public static Domain.Character To(Character character)
        {
            return null;
        }

        #endregion
    }
}
