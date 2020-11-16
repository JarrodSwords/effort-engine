using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private Loadout _loadout;

        public Character(CharacterBuilderBase builderBase) : base(builderBase.Id)
        {
            CharacterType = builderBase.CharacterType;
            _loadout = builderBase.Loadout;
            NaturalStats = builderBase.NaturalStats;
            CalculateEffectiveStats();

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public Stats NaturalStats { get; }

        public Loadout Loadout
        {
            get => _loadout;
            private set
            {
                _loadout = value;
                CalculateEffectiveStats();
            }
        }

        public Equipment Accessory => Loadout.Accessory;
        public Equipment Armor => Loadout.Armor;
        public Equipment Weapon => Loadout.Weapon;

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            Validator.ValidateAndThrow(this);
            return this;
        }

        public Character Unequip(Id id)
        {
            Loadout = Loadout.Unequip(id);
            return this;
        }

        #endregion

        #region Private Interface

        private void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats + Loadout.Stats;
        }

        #endregion
    }
}
