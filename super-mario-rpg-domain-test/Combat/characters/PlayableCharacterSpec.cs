using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayableCharacterSpec : CharacterSpec
    {
        private readonly PlayableCharacter _mario;

        #region Creation

        public PlayableCharacterSpec()
        {
            _mario = new MarioBuilder();
        }

        #endregion

        #region Protected Interface

        protected override Entity CreateEntity() => _mario;
        protected override Entity CreateEntity(Guid id) => new MarioBuilder().With(id);

        #endregion
    }
}
