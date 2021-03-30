using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterRepository : IRepository<Character>
    {
        #region Public Interface

        Character Find(Name name);

        #endregion
    }
}
