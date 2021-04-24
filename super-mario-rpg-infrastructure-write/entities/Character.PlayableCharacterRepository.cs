using System.Linq;
using Effort.Domain;
using Microsoft.EntityFrameworkCore;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Creation

        public Character(PlayableCharacter playableCharacter) : this(playableCharacter as Domain.Character)
        {
            CombatStats = playableCharacter.BaseStats;
        }

        #endregion

        #region Public Interface

        public static Character AsCharacter(PlayableCharacter playableCharacter)
        {
            return playableCharacter;
        }

        public Character Update(PlayableCharacter playableCharacter)
        {
            CombatStats.Update(playableCharacter.BaseStats);
            return this;
        }

        #endregion

        #region Equality, Operators

        public static implicit operator PlayableCharacter(Character character)
        {
            return new(character);
        }

        public static implicit operator Character(PlayableCharacter playableCharacter)
        {
            return new(playableCharacter);
        }

        #endregion

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
                return base.Create(playableCharacter).Name;
            }

            public void Create(params PlayableCharacter[] playableCharacters)
            {
                Create(playableCharacters.Select(AsCharacter).ToArray());
            }

            public PlayableCharacter Find(Name name)
            {
                return Context.Character
                    .Include(x => x.CombatStats)
                    .Single(x => x.IsPlayable && x.Name == name);
            }

            public void Update(PlayableCharacter playableCharacter)
            {
                var character = Context.Character
                    .Include(x => x.CombatStats)
                    .Single(x => x.IsPlayable && x.Name == playableCharacter.Name)
                    .Update(playableCharacter);

                base.Update(character);
            }

            #endregion
        }

        #endregion
    }
}
