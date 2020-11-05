using System;

namespace Effort.Domain
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
        where T : ValueObject<T>
    {
        #region Equality, Operators

        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((ValueObject<T>) obj);
        }

        public bool Equals(ValueObject<T> other) => throw new NotImplementedException();

        public override int GetHashCode() => throw new NotImplementedException();

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => Equals(left, right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !Equals(left, right);

        #endregion
    }
}
