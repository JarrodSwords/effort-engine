using System;

namespace Effort.Domain
{
    public abstract class TinyTypeOfString : TinyType<string>
    {
        private readonly StringComparison _stringComparison;

        #region Creation

        protected TinyTypeOfString(
            string value,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase
        ) : base(value)
        {
            _stringComparison = stringComparison;
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(TinyType<string> other) =>
            string.Compare(Value, other.Value, _stringComparison) == 0;

        #endregion
    }
}
