namespace Effort.Domain
{
    public class Name : TinyTypeOfString
    {
        #region Creation

        private Name(string value) : base(value)
        {
        }

        public static Name CreateName(string value) => new Name(value);

        #endregion
    }
}
