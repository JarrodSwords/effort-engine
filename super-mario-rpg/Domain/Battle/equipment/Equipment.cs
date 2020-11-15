using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Equipment : ValueObject<Equipment>
    {
        #region Core

        public Equipment(
            string name,
            Slot slot,
            Stats stats,
            Characters compatibleCharacters
        )
        {
            Name = Name.Create(name);
            Slot = slot;
            Stats = stats;
            CompatibleCharacters = compatibleCharacters;
        }

        private Equipment(Equipment equipment) : this(
            equipment.Name.Value,
            equipment.Slot,
            equipment.Stats,
            equipment.CompatibleCharacters
        )
        {
        }

        #endregion

        #region Public Interface

        public Characters CompatibleCharacters { get; }
        public Name Name { get; }
        public Slot Slot { get; }
        public Stats Stats { get; }

        public Equipment Clone() => new Equipment(this);

        public override string ToString() => Name.ToString();

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Equipment other) => Slot == other.Slot && Name == other.Name;
        protected override int GetHashCodeExplicit() => Slot.GetHashCode() + Name.GetHashCode();

        #endregion
    }
}
