using System;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public partial class Character
    {
        #region Nested Types

        public interface IBuilder
        {
            #region Public Interface

            CharacterTypes GetCharacterTypes();
            Enemy.CombatStats GetCombatStats();
            Guid GetId();
            string GetName();

            #endregion
        }

        #endregion
    }
}
