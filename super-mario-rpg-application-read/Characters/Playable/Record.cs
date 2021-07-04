using System.Diagnostics.CodeAnalysis;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Playable
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal record Record(
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

        public static Fetch.PlayableCharacter AsPlayableCharacter(Record record) => record;

        public static implicit operator Fetch.PlayableCharacter(Record record)
        {
            var (name, hitPoints, speed, attack, magicAttack, defense, magicDefense) = record;

            return new Fetch.PlayableCharacter(
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
