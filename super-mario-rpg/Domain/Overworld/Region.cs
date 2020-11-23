using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public class Region : ValueObject<Region>
    {
        #region Creation

        public Region(string name)
        {
            Name = Name.CreateName(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Region other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
