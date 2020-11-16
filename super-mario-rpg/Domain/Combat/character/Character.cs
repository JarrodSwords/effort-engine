using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private Loadout _loadout;

        public Character(CharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            _loadout = builder.Loadout;
            NaturalStats = builder.NaturalStats;
            Level = builder.Level;
            ExperiencePoints = builder.ExperiencePoints;
            CalculateEffectiveStats();

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public ExperiencePoints ExperiencePoints { get; set; }
        public byte Level { get; set; }
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

        public Character Add(ExperiencePoints experiencePoints)
        {
            ExperiencePoints += experiencePoints;
            return this;
        }

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
