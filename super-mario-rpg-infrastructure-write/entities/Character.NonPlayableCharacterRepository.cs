using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Public Interface

        public static Character AsCharacter(NonPlayableCharacter nonPlayableCharacter)
        {
            return nonPlayableCharacter;
        }

        #endregion

        #region Equality, Operators

        public static implicit operator Character(NonPlayableCharacter nonPlayableCharacter)
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
                return base.Create(nonPlayableCharacter).Name;
            }

            public void Create(params NonPlayableCharacter[] nonPlayerCharacters)
            {
                var characters = nonPlayerCharacters.Select(AsCharacter).ToArray();

                Create(characters);
            }

            #endregion
        }

        #endregion
    }
}
