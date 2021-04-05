using System;

namespace Effort.Domain.Test
{
    public class IdSpec : TinyTypeSpec<Guid>
    {
        #region Protected Interface

        protected override TinyType<Guid> CreateTinyType(Guid value)
        {
            return new Id(value);
        }

        protected override Guid CreateValue()
        {
            return Guid.NewGuid();
        }

        #endregion
    }
}
