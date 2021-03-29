using Effort.Domain;
using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgres
{
    public class CharacterRepository : Domain.IRepository<DomainCharacter>
    {
        private readonly RepositoryAdapter<DomainCharacter, Character> _adapter;

        #region Creation

        public CharacterRepository(RepositoryAdapter<DomainCharacter, Character> adapter)
        {
            _adapter = adapter;
        }

        #endregion

        #region IRepository<Character> Implementation

        public void Commit()
        {
            _adapter.Commit();
        }

        public string Create(DomainCharacter aggregateRoot)
        {
            return _adapter.Create(Character.From(aggregateRoot)).Name;
        }

        public DomainCharacter Find(Id id)
        {
            return _adapter.Find(id.Value).To();
        }

        public void Update(DomainCharacter aggregateRoot)
        {
            var character = _adapter.Find(aggregateRoot.Id.Value);

            character.Name = aggregateRoot.Name.Value;

            _adapter.Update(character);
        }

        #endregion
    }
}
