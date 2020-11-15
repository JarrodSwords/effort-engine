using System;
using Effort.Domain;
using Effort.Test.Domain;
using SuperMarioRpg.Domain.Battle;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class CharacterSpec : EntitySpec
    {
        #region Protected Interface

        protected override Entity CreateEntity() => new Character();
        protected override Entity CreateEntity(Guid id) => new Character(id);

        #endregion
    }
}
