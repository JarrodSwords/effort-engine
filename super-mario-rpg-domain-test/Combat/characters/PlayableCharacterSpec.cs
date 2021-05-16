using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayableCharacterSpec : CharacterSpec
    {
        private readonly MarioBuilder _marioBuilder = new();

        #region Protected Interface

        protected override Entity CreateEntity() => _marioBuilder;
        protected override Entity CreateEntity(Guid id) => _marioBuilder.With(id);

        #endregion
    }
}
