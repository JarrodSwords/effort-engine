using Effort.Domain;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public abstract class Equipment : ValueObject<Equipment>
    {
        #region Core

        protected Equipment(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
