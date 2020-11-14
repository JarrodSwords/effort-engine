namespace Effort.Domain
{
    public class Name : TinyTypeOfString
    {
        #region Core

        private Name(string value) : base(value)
        {
        }

        #endregion

        #region Public Interface

        public static Name Create(string value) => new Name(value);

        #endregion
    }
}
