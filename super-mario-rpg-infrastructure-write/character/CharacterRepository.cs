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

        public string Create(Domain.Character playerCharacter)
        {
            return Create(Character.From(playerCharacter)).Name;
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
