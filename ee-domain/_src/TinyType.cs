namespace Effort.Domain
{
    public abstract class TinyType<T>
    {
        #region Core

        protected TinyType(T value)
        {
            Value = value;
        }

        #endregion

        #region Public Interface

        public T Value { get; }

        #endregion
    }
}
