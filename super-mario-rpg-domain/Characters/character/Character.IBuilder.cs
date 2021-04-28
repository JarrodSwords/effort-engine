using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Characters
{
    public partial class Character
    {
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
    }
}
