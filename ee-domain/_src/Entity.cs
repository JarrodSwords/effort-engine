using System;

namespace Effort.Domain
{
    public abstract class Entity
    {
        #region Core

        protected Entity(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
        }

        #endregion

        #region Public Interface

        public Guid Id { get; }

        #endregion
    }
}
