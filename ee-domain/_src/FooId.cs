using System;

namespace Effort.Domain
{
    public class FooId : Id
    {
        #region Core

        public FooId(Guid id = new Guid()) : base(id)
        {
        }

        #endregion
    }
}
