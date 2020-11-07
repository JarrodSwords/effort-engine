using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class IdSpec : TinyTypeSpec<Guid>
    {
        #region Protected Interface

        protected override TinyType<Guid> CreateTinyType() => new Id();

        #endregion
    }
}
