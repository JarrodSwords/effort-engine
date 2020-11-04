namespace Effort.Domain
{
    public class Foo : Entity<FooId>
    {
        #region Core

        public Foo(FooId id = null) : base(id)
        {
        }

        #endregion

        #region Protected Interface

        protected override FooId CreateId() => new FooId();

        #endregion
    }
}
