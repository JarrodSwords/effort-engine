using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Nested Types

        public class NonPlayerCharacterRepository : Repository<Character>, NonPlayerCharacter.IRepository
        {
            #region Creation

            public NonPlayerCharacterRepository(Context context) : base(context)
            {
            }

            #endregion

            #region IRepository Implementation

            public string Create(NonPlayerCharacter nonPlayerCharacter)
            {
                return Create(From(nonPlayerCharacter)).Name;
            }

            public void Create(params NonPlayerCharacter[] nonPlayerCharacters)
            {
                var characters = nonPlayerCharacters.Select(From).ToArray();

                Create(characters);
            }

            #endregion
        }

        #endregion
    }
}
