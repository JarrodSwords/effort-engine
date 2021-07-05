﻿using System.Diagnostics.CodeAnalysis;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
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
  join combat_stats cs
    on cs.id = c.combat_stats_id
 where c.is_playable = false";

        #region Public Interface

        public static string Fetch =>
            $@"{Select}
 order by c.name";

        public static string Find =>
            $@"{Select}
   and name = @Name";

        #endregion

        #region Static Interface

        public static Enemy AsEnemy(EnemyRecord enemyRecord) => enemyRecord;

        public static implicit operator Enemy(EnemyRecord enemyRecord)
        {
            var (name, hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade, magicEvade) =
                enemyRecord;

            return new Enemy(
                name,
                new EnemyCombatStats(
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