using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class IdSpec : TinyTypeSpec<Guid>
    {
        #region Protected Interface

        protected override TinyType<Guid> CreateTinyType(Guid value) => Id.CreateId(value);
        protected override Guid CreateValue() => Guid.NewGuid();

        #endregion
    }
}
