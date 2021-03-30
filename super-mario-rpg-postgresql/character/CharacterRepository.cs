using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgresql
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        #region Creation

        public CharacterRepository(Context context) : base(context)
        {
        }

        #endregion

        #region ICharacterRepository Implementation

        public DomainCharacter Find(Name name)
        {
            return Character.To(Find(x => x.Name == name.Value));
        }

        #endregion

        #region IRepository<Character> Implementation

        public string Create(DomainCharacter character)
        {
            return Create(Character.From(character)).Name;
        }

        public DomainCharacter Find(Id id)
        {
            return Character.To(Find(id.Value));
        }

        public void Update(DomainCharacter character)
        {
            var storedCharacter = Find(character.Id.Value);

            storedCharacter.Name = character.Name.Value;

            Update(storedCharacter);
        }

        #endregion
    }
}
