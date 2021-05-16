namespace Effort.Domain
{
    public abstract class Entity
    {
        #region Creation

        protected Entity(Id id)
        {
            Id = new Id(id);
        }

        #endregion

        #region Public Interface

        public Id Id { get; }

        #endregion

        #region Equality

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

        #endregion

        #region Static Interface

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null)
                return right is null;

            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right) => !Equals(left, right);

        #endregion
    }
}
