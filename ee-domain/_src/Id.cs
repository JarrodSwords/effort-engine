using System;

namespace Effort.Domain
{
    public class Id : TinyType<Guid>
    {
        #region Core

        public Id(Guid value = new Guid()) : base(
            value == Guid.Empty
                ? Guid.NewGuid()
                : value
        )
        {
        }

        #endregion
    }
}
