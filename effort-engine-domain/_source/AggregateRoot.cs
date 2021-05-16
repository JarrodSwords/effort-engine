namespace Effort.Domain
{
    public abstract class AggregateRoot : Entity
    {
        #region Creation

        protected AggregateRoot(Id id) : base(id)
        {
        }

        #endregion
    }
}
