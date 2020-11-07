using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public class Region : ValueObject<Region>
    {
        #region Core

        public Region(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Region other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
