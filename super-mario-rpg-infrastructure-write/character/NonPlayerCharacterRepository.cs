using System;
using System.Linq;
using Effort.Domain;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class NonPlayerCharacterRepository : Repository<Character>, NonPlayerCharacter.IRepository
    {
        #region Creation

        public NonPlayerCharacterRepository(Context context) : base(context)
        {
        }

        #endregion

        #region Public Interface

        public NonPlayerCharacter Find(Id id)
        {
            throw new NotImplementedException();
        }

        public void Update(NonPlayerCharacter character)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository Implementation

        public string Create(NonPlayerCharacter nonPlayerCharacter)
        {
            return Create(Character.From(nonPlayerCharacter)).Name;
        }

        public void Create(params NonPlayerCharacter[] nonPlayerCharacters)
        {
            var characters = nonPlayerCharacters.Select(Character.From).ToArray();

            Create(characters);
        }

        #endregion
    }
}
