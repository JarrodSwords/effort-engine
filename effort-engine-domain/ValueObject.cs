using System.Collections.Generic;
using System.Linq;

namespace Effort.Domain
{
    public abstract class ValueObject
    {
        #region Equality, Operators

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            var valueObject = (ValueObject) other;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(
                    1,
                    (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    }
                );
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        #endregion
    }
}
