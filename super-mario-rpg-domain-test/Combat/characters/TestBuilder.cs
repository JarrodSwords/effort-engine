using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class TestBuilder : IPlayerCharacterBuilder
    {
        private Id _id;

        #region Public Interface

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
