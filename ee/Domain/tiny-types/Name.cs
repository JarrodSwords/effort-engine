namespace Effort.Domain
{
    public record Name : TinyType<string>
    {
        #region Creation

        private Name(string value) : base(value)
        {
        }

        public static Name CreateName(string value) => new(value);

        #endregion
    }
}
