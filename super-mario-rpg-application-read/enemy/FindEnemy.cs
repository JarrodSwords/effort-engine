using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindEnemy(string Name) : IQuery<Enemy>
    {
        #region Nested Types

        internal class Handler : Handler<FindEnemy, Enemy>
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
 where name = @Name
   and c.is_enemy = true
";

            #region Public Interface

            public override Enemy MakeRequest(IDbConnection connection, FindEnemy query)
            {
                return EnemyRecord.AsEnemy(
                    connection.QuerySingle<EnemyRecord>(FetchEnemies, query)
                );
            }

            #endregion
        }

        #endregion
    }
}
