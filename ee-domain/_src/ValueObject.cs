using System;

namespace Effort.Domain
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
        where T : ValueObject<T>
    {
        #region Equality, Operators

        public override bool Equals(object obj)
        {
            if (!(obj is T valueObject))
                return false;
            if (ReferenceEquals(this, valueObject))
                return true;
            if (valueObject.GetType() != GetType())
                return false;
            return EqualsExplicit(valueObject);
        }

        public bool Equals(ValueObject<T> other) => throw new NotImplementedException();

        protected abstract bool EqualsExplicit(T other);

        public override int GetHashCode() => GetHashCodeExplicit();
        protected abstract int GetHashCodeExplicit();

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => Equals(left, right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !Equals(left, right);

        #endregion
    }
}
