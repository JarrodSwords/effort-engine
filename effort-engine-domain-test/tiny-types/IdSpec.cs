using System;

namespace Effort.Domain.Test
{
    public class IdSpec : ValueObjectSpec
    {
        private static readonly Guid Id = Guid.NewGuid();

        #region Protected Interface

        protected override ValueObject Create() => new Id(Id);
        protected override ValueObject CreateOther() => new Id();

        #endregion
    }
}
