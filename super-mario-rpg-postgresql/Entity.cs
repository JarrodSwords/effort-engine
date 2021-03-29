using System;

namespace SuperMarioRpg.Postgresql
{
    public abstract class Entity
    {
        #region Public Interface

        public Guid Id { get; set; }

        #endregion
    }
}
