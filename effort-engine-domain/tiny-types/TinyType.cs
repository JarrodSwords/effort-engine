namespace Effort.Domain
{
    public abstract record TinyType<T>(T Value)
    {
        #region Public Interface

        public override string ToString()
        {
            return Value.ToString();
        }

        #endregion
    }
}
