using System;

namespace Effort.Domain
{
    public class Id : TinyType<Guid>
    {
        #region Core

        private Id(Guid value) : base(value == default ? Guid.NewGuid() : value)
        {
        }

        #endregion

        #region Public Interface

        public static Id Create(Guid value = default) => new Id(value);

        #endregion
    }
}
