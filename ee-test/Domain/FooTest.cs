using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class FooTest : EntityBaseTest
    {
        #region Test Methods

        protected override Entity CreateEntity(Guid id)
        {
            return new Foo(new Id(id));
        }

        protected override Entity CreateEntity()
        {
            return new Foo();
        }

        #endregion
    }
}
