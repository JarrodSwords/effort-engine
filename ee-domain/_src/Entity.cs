using System;
using System.Collections.Generic;

namespace Effort.Domain
{
    public abstract class Entity<T> : IEquatable<Entity<T>>
        where T : Id
    {
        #region Core

        private T _id;

        protected Entity(T id)
        {
            _id = id;
        }

        #endregion

        #region Public Interface

        public T Id => _id ??= CreateId();

        #endregion

        #region Protected Interface

        protected abstract T CreateId();

        #endregion

        #region Equality, Operators

        public bool Equals(Entity<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return EqualityComparer<T>.Default.Equals(_id, other._id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Entity<T>) obj);
        }

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(_id);

        public static bool operator ==(Entity<T> left, Entity<T> right) => Equals(left, right);

        public static bool operator !=(Entity<T> left, Entity<T> right) => !Equals(left, right);

        #endregion
    }
}
