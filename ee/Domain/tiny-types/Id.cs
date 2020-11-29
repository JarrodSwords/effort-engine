using System;

namespace Effort.Domain
{
    public record Id : TinyType<Guid>
    {
        #region Creation

        private Id(Guid value) : base(value == default ? Guid.NewGuid() : value)
        {
        }

        #endregion

        #region Public Interface

        public static Id CreateId(Guid value = default) => new(value);

        #endregion
    }
}
