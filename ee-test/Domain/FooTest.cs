using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class FooTest : EntitySpec
    {
        #region Test Methods

        protected override Entity CreateDifferentEntity(Guid id)
        {
            var foo = CreateEntity(id) as Foo;
            foo.Bar = 1;
            return foo;
        }

        protected override Entity CreateEntity(Guid id) => new Foo(id);
        protected override Entity CreateEntity() => new Foo();

        #endregion
    }
}
