using System.Diagnostics.CodeAnalysis;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal record EnemyRecord(
        string name,
        int hit_points,
        short flower_points,
        short speed,
        short attack,
        short magic_attack,
        short defense,
        short magic_defense,
        decimal evade,
        decimal magic_evade
    )
    {
        private const string Select = @"
select c.name
     , cs.hit_points
     , cs.flower_points
     , cs.speed
     , cs.attack
     , cs.magic_attack 
     , cs.defense 
     , cs.magic_defense 
     , cs.evade 
     , cs.magic_evade 
  from character c
  left join combat_stats cs
    on cs.id = c.combat_stats_id";

        #region Public Interface

        public static string Fetch =>
            $@"{Select}
 where c.is_enemy = true
 order by c.name
";

        public static string Find =>
            $@"{Select}
 where name = @Name
   and c.is_enemy = true 
";

        public static Enemy AsEnemy(EnemyRecord record)
        {
            var (name, hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade,
                    magicEvade) =
                record;

            return new Enemy(
                name,
                new CombatStats(
                    (ushort) hitPoints,
                    (byte?) flowerPoints,
                    speed,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense,
                    evade,
                    magicEvade
                )
            );
        }

        #endregion
    }
}
