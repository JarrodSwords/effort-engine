using System;

namespace Effort.Domain
{
    public class Id : TinyType<Guid>
    {
        #region Creation

        private Id(Guid value) : base(value == default ? Guid.NewGuid() : value)
        {
        }

        public static Id CreateId(Guid value = default) => new Id(value);

        #endregion
    }
}
