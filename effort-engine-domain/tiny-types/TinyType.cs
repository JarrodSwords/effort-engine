namespace Effort.Domain
{
    public abstract record TinyType<T>
    {
        #region Creation

        protected TinyType(T value)
        {
            Value = value;
        }

        #endregion

        #region Public Interface

        public T Value { get; }

        public override string ToString() => Value.ToString();

        #endregion
    }
}
