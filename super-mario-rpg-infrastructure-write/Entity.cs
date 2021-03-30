using System;

namespace SuperMarioRpg.Infrastructure.Write
{
    public abstract class Entity
    {
        #region Public Interface

        public Guid Id { get; set; }

        #endregion
    }
}
