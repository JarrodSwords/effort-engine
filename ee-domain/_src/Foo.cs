using System;

namespace Effort.Domain
{
    public class Foo : Entity
    {
        #region Core

        public Foo(Guid id = new Guid()) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public int Bar { get; set; }

        #endregion
    }
}
