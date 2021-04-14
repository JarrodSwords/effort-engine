using System.Linq;
using Microsoft.EntityFrameworkCore;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Nested Types

        public class PlayableCharacterRepository : Repository<Character>, PlayableCharacter.IRepository
        {
            #region Creation

            public PlayableCharacterRepository(Context context) : base(context)
            {
            }

            #endregion

            #region IRepository Implementation

            public string Create(PlayableCharacter playableCharacter)
            {
                return Create(From(playableCharacter)).Name;
            }

            public void Create(params PlayableCharacter[] playableCharacters)
            {
                Create(playableCharacters.Select(From).ToArray());
            }

            public PlayableCharacter Find(string name)
            {
                return Context.Character
                    .Include(x => x.CombatStats)
                    .Single(x => x.IsPlayable && x.Name == name)
                    .BuildPlayableCharacter();
            }

            public void Update(PlayableCharacter playableCharacter)
            {
                var character = Context.Character
                    .Include(x => x.CombatStats)
                    .Single(x => x.IsPlayable && x.Name == playableCharacter.Name.Value);

                var (hitPoints, speed, attack, magicAttack, defense, magicDefense) = playableCharacter.BaseStats;

                character.CombatStats.HitPoints = hitPoints;
                character.CombatStats.Speed = speed;
                character.CombatStats.Attack = attack;
                character.CombatStats.MagicAttack = magicAttack;
                character.CombatStats.Defense = defense;
                character.CombatStats.MagicDefense = magicDefense;

                Update(character);
            }

            #endregion
        }

        #endregion
    }
}
