using System;
using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class PlayerCharacterSpec : EntitySpec
    {
        #region Protected Interface

        protected override Entity CreateEntity() => new PlayerCharacter();
        protected override Entity CreateEntity(Guid id) => new PlayerCharacter(id);

        #endregion
    }
}
