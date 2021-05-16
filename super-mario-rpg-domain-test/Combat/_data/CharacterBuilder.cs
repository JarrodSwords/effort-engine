using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;
using CombatStats = SuperMarioRpg.Domain.Combat.CombatStats;

namespace SuperMarioRpg.Domain.Test.Combat
{
    internal abstract class CharacterBuilder : IPlayableCharacterBuilder
    {
        private Id _id;

        #region Public Interface

        public CharacterBuilder With(Id id)
        {
            _id = id;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public abstract CharacterTypes GetCharacterTypes();
        public Id GetId() => _id;
        public abstract Name GetName();

        #endregion

        #region IPlayableCharacterBuilder Implementation

        public abstract CombatStats GetCombatStats();

        #endregion

        #region Static Interface

        public static implicit operator PlayableCharacter(CharacterBuilder builder) => new(builder);

        #endregion
    }
}
