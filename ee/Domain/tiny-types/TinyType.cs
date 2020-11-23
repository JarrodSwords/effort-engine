using System;
using System.Collections.Generic;

namespace Effort.Domain
{
    public abstract class TinyType<T> : IEquatable<TinyType<T>>
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

        public bool Equals(TinyType<T> other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return EqualsExplicit(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((TinyType<T>) obj);
        }

        protected virtual bool EqualsExplicit(TinyType<T> other) =>
            EqualityComparer<T>.Default.Equals(Value, other.Value);

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);
        public static bool operator ==(TinyType<T> left, TinyType<T> right) => Equals(left, right);
        public static bool operator !=(TinyType<T> left, TinyType<T> right) => !Equals(left, right);

        #endregion
    }
}
