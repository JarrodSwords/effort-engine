using System;
using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class EquipmentSpec : EntitySpec
    {
        #region Protected Interface

        protected override Entity CreateEntity() => new Equipment(null);
        protected override Entity CreateEntity(Guid id) => new Equipment(id);

        #endregion
    }
}
