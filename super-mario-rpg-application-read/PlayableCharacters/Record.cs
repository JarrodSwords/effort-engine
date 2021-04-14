using System.Diagnostics.CodeAnalysis;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.PlayableCharacters
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal record Record(
        string name,
        int hit_points,
        short speed,
        short attack,
        short magic_attack,
        short defense,
        short magic_defense
    )
    {
        private const string Select = @"
select c.name
     , cs.hit_points
     , cs.speed
     , cs.attack
     , cs.magic_attack 
     , cs.defense 
     , cs.magic_defense
  from character c
  join combat_stats cs
    on cs.id = c.combat_stats_id
 where c.is_playable = true";

        #region Public Interface

        public static string Fetch =>
            $@"{Select}
 order by c.name";

        public static string Find =>
            $@"{Select}
   and name = @Name";

        public PlayableCharacter AsPlayableCharacter()
        {
            return AsPlayableCharacter(this);
        }

        public static PlayableCharacter AsPlayableCharacter(Record record)
        {
            var (name, hitPoints, speed, attack, magicAttack, defense, magicDefense) =
                record;

            return new PlayableCharacter(
                name,
                new PlayableCharacterCombatStats(
                    (ushort) hitPoints,
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
