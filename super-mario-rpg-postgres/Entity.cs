using System;

namespace SuperMarioRpg.Postgres
{
    public abstract class Entity<T>
    {
        #region Public Interface

        public Guid Id { get; set; }

        public abstract T To();

        #endregion
    }
}
