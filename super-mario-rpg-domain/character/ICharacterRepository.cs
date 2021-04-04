using System;

namespace SuperMarioRpg.Domain
{
    public interface ICharacterRepository : IRepository<Character>
    {
    }

    public interface ICharacterBuilder
    {
        #region Public Interface

        Guid GetId();
        string GetName();

        #endregion
    }
}
