using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchEnemies : IQuery<IEnumerable<Enemy>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchEnemies, IEnumerable<Enemy>>
        {
            private const string FetchEnemies = @"
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
    on cs.id = c.combat_stats_id
 where c.is_enemy = true
 order by c.name
";

            #region Public Interface

            public override IEnumerable<Enemy> MakeRequest(IDbConnection connection, FetchEnemies query)
            {
                return connection
                    .Query<FetchEnemiesRecord>(FetchEnemies)
                    .Select(FetchEnemiesRecord.AsEnemy);
            }

            #endregion

            #region Nested Types

            private record FetchEnemiesRecord(
                string name,
                int hit_points,
                short flower_points,
                short speed,
                short attack,
                short magic_attack,
                short defense,
                short magic_defense,
                decimal? evade,
                decimal? magic_evade
            )
            {
                #region Public Interface

                public static Enemy AsEnemy(FetchEnemiesRecord record)
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

            #endregion
        }

        #endregion
    }
}
