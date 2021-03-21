using System;

namespace Effort.Domain
{
    public abstract class Entity
    {
        #region Creation

        protected Entity(Guid id)
        {
            Id = Id.Create(id);
        }

        #endregion

        #region Public Interface

        public Id Id { get; }

        #endregion

        #region Equality, Operators

        public override bool Equals(object other)
        {
            if (other is null)
                return false;

            if (GetType() != other.GetType())
                return false;

            var otherEntity = (Entity) other;

            return Id == otherEntity.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right) => !Equals(left, right);

        #endregion
    }
}
