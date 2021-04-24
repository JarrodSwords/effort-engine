using System;

namespace Effort.Domain
{
    public class Id : TinyType<Guid>
    {
        #region Creation

        public Id(Guid value = default) : base(value == default ? Guid.NewGuid() : value)
        {
        }

        #endregion

        #region Equality, Operators

        public static implicit operator Id(Guid id)
        {
            return new(id);
        }

        #endregion
    }
}
