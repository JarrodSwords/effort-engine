using System;

namespace Effort.Domain
{
    public class Name : TinyType<string>
    {
        #region Core

        public Name(string value) : base(value)
        {
        }

        #endregion

        #region Equality, Operators

        public override bool EqualsExplicit(TinyType<string> other) =>
            string.Compare(Value, other.Value, StringComparison.OrdinalIgnoreCase) == 0;

        #endregion
    }
}
