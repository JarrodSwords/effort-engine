using System;
using Effort.Domain;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        #region Creation

        public CharacterRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IRepository<Character> Implementation

        public string Create(Domain.Character character)
        {
            return Create(Character.From(character)).Name;
        }

        public void Create(params Domain.Character[] root)
        {
            throw new NotImplementedException();
        }

        public Domain.Character Find(Id id)
        {
            return Character.To(Find(id.Value));
        }

        public void Update(Domain.Character character)
        {
            var storedCharacter = Find(character.Id.Value);

            storedCharacter.Name = character.Name.Value;

            Update(storedCharacter);
        }

        #endregion
    }
}
