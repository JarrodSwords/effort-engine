using System.Linq;
using Microsoft.EntityFrameworkCore;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Creation

        public Character(PlayableCharacter playableCharacter) : this(playableCharacter as Domain.Character)
        {
            CombatStats = CombatStats.From(playableCharacter.BaseStats);
        }

        #endregion

        #region Public Interface

        public PlayableCharacter AsPlayableCharacter()
        {
            return new(this);
        }

        public static Character From(PlayableCharacter playableCharacter)
        {
            return new(playableCharacter);
        }

        public Character Update(PlayableCharacter playableCharacter)
        {
            CombatStats.Update(playableCharacter.BaseStats);
            return this;
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
                    .AsPlayableCharacter();
            }

            public void Update(PlayableCharacter playableCharacter)
            {
                var character = Context.Character
                    .Include(x => x.CombatStats)
                    .Single(x => x.IsPlayable && x.Name == playableCharacter.Name.Value)
                    .Update(playableCharacter);

                Update(character);
            }

            #endregion
        }

        #endregion
    }
}
