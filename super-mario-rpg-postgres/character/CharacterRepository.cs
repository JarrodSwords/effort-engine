using Effort.Domain;
using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgres
{
    public class CharacterRepository : Domain.IRepository<DomainCharacter>
    {
        private readonly Repository<Character> _repository;

        #region Creation

        public CharacterRepository(Repository<Character> repository)
        {
            _repository = repository;
        }

        #endregion

        #region IRepository<Character> Implementation

        public void Commit()
        {
            _repository.Commit();
        }

        public string Create(DomainCharacter aggregateRoot)
        {
            return _repository.Create(Character.From(aggregateRoot)).Name;
        }

        public DomainCharacter Find(Id id)
        {
            return Character.To(_repository.Find(id.Value));
        }

        public void Update(DomainCharacter aggregateRoot)
        {
            var character = _repository.Find(aggregateRoot.Id.Value);

            character.Name = aggregateRoot.Name.Value;

            _repository.Update(character);
        }

        #endregion
    }
}
