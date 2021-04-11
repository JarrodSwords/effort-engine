using System.Linq;
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

            #region Public Interface

            public string Create(PlayableCharacter playableCharacter)
            {
                return Create(From(playableCharacter)).Name;
            }

            public void Create(params PlayableCharacter[] playableCharacters)
            {
                Create(playableCharacters.Select(From).ToArray());
            }

            #endregion
        }

        #endregion
    }
}
