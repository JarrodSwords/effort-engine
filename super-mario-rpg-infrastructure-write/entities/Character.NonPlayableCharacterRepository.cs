using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Public Interface

        public static Character From(NonPlayableCharacter nonPlayableCharacter)
        {
            return new(nonPlayableCharacter);
        }

        #endregion

        #region Nested Types

        public class NonPlayableCharacterRepository : Repository<Character>, NonPlayableCharacter.IRepository
        {
            #region Creation

            public NonPlayableCharacterRepository(Context context) : base(context)
            {
            }

            #endregion

            #region IRepository Implementation

            public string Create(NonPlayableCharacter nonPlayableCharacter)
            {
                return Create(From(nonPlayableCharacter)).Name;
            }

            public void Create(params NonPlayableCharacter[] nonPlayerCharacters)
            {
                var characters = nonPlayerCharacters.Select(From).ToArray();

                Create(characters);
            }

            #endregion
        }

        #endregion
    }
}
