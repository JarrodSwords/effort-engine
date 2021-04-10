using System;

namespace SuperMarioRpg.Domain
{
    public interface ICharacterBuilder
    {
        #region Public Interface

        CombatStats GetCombatStats();
        Guid GetId();
        string GetName();

        #endregion
    }
}
