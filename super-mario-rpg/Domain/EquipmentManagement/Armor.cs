using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class Armor : ValueObject<Armor>
    {
        #region Core

        public Armor(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Armor other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
