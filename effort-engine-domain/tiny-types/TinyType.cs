using System.Collections.Generic;
using System.Diagnostics;

namespace Effort.Domain
{
    [DebuggerDisplay("{Value}")]
    public abstract class TinyType<T> : ValueObject
    {
        #region Creation

        protected TinyType(T value)
        {
            Value = value;
        }

        #endregion

        #region Protected Interface

        protected T Value { get; }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            if (other is null)
                return false;

            return other.GetType() == typeof(T)
                ? Equals((T) other)
                : base.Equals(other);
        }

        public bool Equals(T other)
        {
            return ((T) this).Equals(other);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Static Interface

        public static bool operator ==(TinyType<T> left, TinyType<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TinyType<T> left, TinyType<T> right)
        {
            return !Equals(left, right);
        }

        public static implicit operator T(TinyType<T> instance)
        {
            return instance is null ? default : instance.Value;
        }

        #endregion
    }
}
