using System;
using SuperMarioRpg.Domain.Combat;

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
