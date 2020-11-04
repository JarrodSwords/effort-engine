namespace Effort.Domain
{
    public abstract class Entity<T> where T : Id
    {
        #region Core

        private T _id;

        protected Entity(T id)
        {
            _id = id;
        }

        #endregion

        #region Public Interface

        public T Id => _id ??= CreateId();

        #endregion

        #region Protected Interface

        protected abstract T CreateId();

        #endregion
    }
}
