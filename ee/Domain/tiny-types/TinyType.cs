using System.Collections.Generic;

#pragma warning disable 660,661

namespace Effort.Domain
{
    public abstract class TinyType<T> : ValueObject
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

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator ==(TinyType<T> left, TinyType<T> right) => Equals(left, right);
        public static bool operator !=(TinyType<T> left, TinyType<T> right) => !Equals(left, right);

        #endregion
    }
}
