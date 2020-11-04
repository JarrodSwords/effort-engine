using System;

namespace Effort.Domain
{
    public abstract class Id : TinyType<Guid>
    {
        #region Core

        protected Id(Guid value = new Guid()) : base(
            value == Guid.Empty
                ? Guid.NewGuid()
                : value
        )
        {
        }

        #endregion
    }
}
