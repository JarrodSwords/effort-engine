using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class PlayerCharacterRepository : Repository<Character>, IPlayerCharacterRepository
    {
        #region Creation

        public PlayerCharacterRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IPlayerCharacterRepository Implementation

        public PlayerCharacter Find(Name name)
        {
            return Character.To(Find(x => x.Name == name.Value));
        }

        #endregion

        #region IRepository<PlayerCharacter> Implementation

        public string Create(PlayerCharacter playerCharacter)
        {
            return Create(Character.From(playerCharacter)).Name;
        }

        public PlayerCharacter Find(Id id)
        {
            return Character.To(Find(id.Value));
        }

        public void Update(PlayerCharacter playerCharacter)
        {
            var storedCharacter = Find(playerCharacter.Id.Value);

            storedCharacter.Name = playerCharacter.Name.Value;

            Update(storedCharacter);
        }

        #endregion
    }
}
