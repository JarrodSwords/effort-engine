using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IPlayerCharacterRepository : IRepository<PlayerCharacter>
    {
        #region Public Interface

        PlayerCharacter Find(Name name);

        #endregion
    }
}
