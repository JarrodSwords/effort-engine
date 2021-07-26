using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;
using IPlayerCharacterBuilder = SuperMarioRpg.Domain.Combat.IPlayerCharacterBuilder;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class TestBuilder : IPlayerCharacterBuilder
    {
        private CharacterTypes _characterType;
        private Id _id;

        #region Public Interface

        public TestBuilder For(CharacterTypes characterType)
        {
            _characterType = characterType;
            return this;
        }

        public TestBuilder With(Id id)
        {
            _id = id;
            return this;
        }

        #endregion

        #region IPlayerCharacterBuilder Implementation

        public Id GetId() => _id;
        public PlayableCharacter GetPlayableCharacter() => new MarioBuilder();

        #endregion
    }
}
