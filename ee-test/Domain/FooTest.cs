using System;
using Effort.Domain;

namespace Effort.Test.Domain
{
    public class FooTest : EntityBaseTest<FooId>
    {
        #region Test Methods

        protected override Entity<FooId> CreateDifferentEntity(Guid id)
        {
            var foo = CreateEntity(id) as Foo;
            foo.Bar = 1;
            return foo;
        }

        protected override Entity<FooId> CreateEntity(Guid id) => new Foo(new FooId(id));
        protected override Entity<FooId> CreateEntity() => new Foo();

        #endregion
    }
}
