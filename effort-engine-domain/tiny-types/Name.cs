namespace Effort.Domain
{
    public record Name(string Value) : TinyType<string>(Value)
    {
        #region Equality, Operators

        public static explicit operator Name(string name)
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
