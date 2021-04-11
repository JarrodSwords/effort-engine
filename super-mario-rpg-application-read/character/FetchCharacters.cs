using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchCharacters : IQuery<IEnumerable<object>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchCharacters, IEnumerable<dynamic>>
        {
            private const string FetchCharacters = @"
select c.name
     , cs.hit_points
     , cs.attack
     , cs.magic_attack 
     , cs.defense 
     , cs.magic_defense 
     , cs.evade 
     , cs.magic_evade 
     , cs.speed
     , c.is_enemy
     , c.is_non_player_character
  from character c
  left join combat_stats cs
    on cs.id = c.combat_stats_id
";

            #region Public Interface

            public override IEnumerable<object> MakeRequest(IDbConnection connection, FetchCharacters args)
            {
                return connection
                    .Query<CharacterRecord>(FetchCharacters, args)
                    .Select(CharacterRecord.AsMostSpecificType);
            }

            #endregion

            #region Nested Types

            private record CharacterRecord(
                string name,
                int hit_points,
                short attack,
                short magic_attack,
                short defense,
                short magic_defense,
                decimal evade,
                decimal magic_evade,
                short speed,
                bool is_enemy,
                bool is_non_player_character
            )
            {
                #region Public Interface

                public static object AsMostSpecificType(CharacterRecord record)
                {
                    var (name, hitPoints, attack, magicAttack, defense, magicDefense, evade, magicEvade, speed, isEnemy,
                            isNonPlayerCharacter) =
                        record;

                    if (isEnemy)
                        return new Enemy(
                            name,
                            new CombatStats(
                                (ushort) hitPoints,
                                attack,
                                magicAttack,
                                defense,
                                magicDefense,
                                evade,
                                magicEvade,
                                speed
                            )
                        );

                    return isNonPlayerCharacter ? new NonPlayerCharacter(name) : null;
                }

                #endregion
            }

            #endregion
        }

        #endregion
    }
}
