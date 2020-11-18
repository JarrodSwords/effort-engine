using System;

namespace Effort.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        #region Core

        protected Entity(Guid id)
        {
            Id = Id.Create(id);
        }

        #endregion

        #region Public Interface

        public Id Id { get; }

        #endregion

        #region Equality, Operators

        public bool Equals(Entity other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode() => Id != null ? Id.GetHashCode() : 0;
        public static bool operator ==(Entity left, Entity right) => Equals(left, right);
        public static bool operator !=(Entity left, Entity right) => !Equals(left, right);

        #endregion
    }
}
