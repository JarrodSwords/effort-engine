using Effort.Domain;
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
            Enemy.CombatStats GetEnemyCombatStats();
            Id GetId();
            Name GetName();
            PlayableCharacter.CombatStats GetPlayableCharacterCombatStats();

            #endregion
        }

        #endregion
    }
}
