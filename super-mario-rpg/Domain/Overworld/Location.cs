using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public class Location : ValueObject<Location>
    {
        #region Core

        public Location(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Location other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
