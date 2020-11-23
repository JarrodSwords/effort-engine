using System;

namespace Effort.Domain
{
    public abstract class AggregateRoot : Entity
    {
        #region Creation

        protected AggregateRoot(Guid id) : base(id)
        {
        }

        #endregion
    }
}
