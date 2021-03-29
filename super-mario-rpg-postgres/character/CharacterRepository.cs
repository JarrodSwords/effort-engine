using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgres
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRepository<Character> _repository;

        #region Creation

        public CharacterRepository(IRepository<Character> repository)
        {
            _repository = repository;
        }

        #endregion

        #region ICharacterRepository Implementation

        public DomainCharacter Find(Name name)
        {
            return Character.To(_repository.Find(x => x.Name == name.Value));
        }

        #endregion

        #region IRepository<Character> Implementation

        public void Commit()
        {
            _repository.Commit();
        }

        public string Create(DomainCharacter character)
        {
            return _repository.Create(Character.From(character)).Name;
        }

        public DomainCharacter Find(Id id)
        {
            return Character.To(_repository.Find(id.Value));
        }

        public void Update(DomainCharacter character)
        {
            var storedCharacter = _repository.Find(character.Id.Value);

            storedCharacter.Name = character.Name.Value;

            _repository.Update(storedCharacter);
        }

        #endregion
    }
}
