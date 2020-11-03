using System;

namespace Effort.Domain
{
    public abstract class Entity
    {
        #region Core

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Public Interface

        public Guid Id { get; }

        #endregion
    }
}
