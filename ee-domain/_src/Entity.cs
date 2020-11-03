namespace Effort.Domain
{
    public abstract class Entity
    {
        #region Core

        protected Entity(Id id)
        {
            Id = id ?? new Id();
        }

        #endregion

        #region Public Interface

        public Id Id { get; }

        #endregion
    }
}
