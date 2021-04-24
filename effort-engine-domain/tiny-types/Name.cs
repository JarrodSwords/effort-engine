namespace Effort.Domain
{
    public class Name : TinyType<string>
    {
        #region Creation

        public Name(string value) : base(value)
        {
        }

        #endregion

        #region Equality, Operators

        public static implicit operator Name(string name)
        {
            return new(name);
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        #endregion
    }
}
