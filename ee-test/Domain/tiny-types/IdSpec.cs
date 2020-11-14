using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class IdSpec : TinyTypeSpec<Guid>
    {
        #region Protected Interface

        protected override TinyType<Guid> CreateTinyType(Guid value) => new Id(value);
        protected override Guid CreateValue() => Guid.NewGuid();

        #endregion
    }
}
