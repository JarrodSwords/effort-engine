using System.Collections.Generic;
using System.Linq;

namespace Effort.Domain
{
    /// <remarks>https://enterprisecraftsmanship.com/posts/value-object-better-implementation/</remarks>
    public abstract class ValueObject
    {
        #region Equality, Operators

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject) obj;

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
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);

        #endregion
    }
}
