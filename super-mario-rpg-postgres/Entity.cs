using System;

namespace SuperMarioRpg.Postgres
{
    public abstract class Entity
    {
        #region Public Interface

        public Guid Id { get; set; }

        #endregion
    }
}
