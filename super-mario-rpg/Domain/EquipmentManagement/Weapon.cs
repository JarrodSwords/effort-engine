using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Weapon : ValueObject<Weapon>
    {
        #region Core

        public Weapon(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Weapon other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
