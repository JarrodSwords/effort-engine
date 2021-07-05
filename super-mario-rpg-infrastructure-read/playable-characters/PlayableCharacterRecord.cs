using System.Diagnostics.CodeAnalysis;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal record PlayableCharacterRecord(
        string name,
        short hit_points,
        short speed,
        short attack,
        short magic_attack,
        short defense,
        short magic_defense
    )
    {
        private const string Select = @"
select c.name
     , s.hit_points
     , s.speed
     , s.attack
     , s.magic_attack 
     , s.defense 
     , s.magic_defense
  from character c
  join statistics s
    on s.id = c.statistics_id
 where c.is_playable = true";

        #region Public Interface

        public static string Fetch =>
            $@"{Select}
 order by c.name";

        public static string Find =>
            $@"{Select}
   and name = @Name";

        #endregion

        #region Static Interface

        public static PlayableCharacter AsPlayableCharacter(
            PlayableCharacterRecord playableCharacterRecord
        ) =>
            playableCharacterRecord;

        public static implicit operator PlayableCharacter(
            PlayableCharacterRecord playableCharacterRecord
        )
        {
            var (name, hitPoints, speed, attack, magicAttack, defense, magicDefense) = playableCharacterRecord;

            return new PlayableCharacter(
                name,
                new PlayableCharacterCombatStats(
                    hitPoints,
                    speed,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense
                )
            );
        }

        #endregion
    }
}
