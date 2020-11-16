using System;

namespace Effort.Domain
{
    public abstract class AggregateRoot : Entity
    {
        #region Core

        protected AggregateRoot(Guid id = new Guid()) : base(id)
        {
        }

        #endregion
    }
}
