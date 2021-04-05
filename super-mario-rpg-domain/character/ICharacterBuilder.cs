using System;

namespace SuperMarioRpg.Domain
{
    public interface ICharacterBuilder
    {
        #region Public Interface

        Guid GetId();
        string GetName();

        #endregion
    }
}
