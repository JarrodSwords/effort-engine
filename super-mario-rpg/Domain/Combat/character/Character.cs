using System;
using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private Loadout _loadout;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            _loadout = builder.Loadout;
            ProgressionSystem = builder.ProgressionSystem;
            CalculateEffectiveStats();

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public Stats NaturalStats => ProgressionSystem.NaturalStats;
        public ExperiencePoints ExperiencePoints => ProgressionSystem.ExperiencePoints;
        public ExperiencePoints ToNext => ProgressionSystem.ToNext;
        public Level Level => ProgressionSystem.Level;

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

        public Character Add(ref ExperiencePoints remainingXp)
        {
            var xpToAdd = new ExperiencePoints(Math.Min(remainingXp.Value, ToNext.Value));
            remainingXp = new ExperiencePoints((ushort) (remainingXp.Value - xpToAdd.Value));

            ProgressionSystem = ProgressionSystem.Add(xpToAdd);
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

        private ProgressionSystem ProgressionSystem { get; set; }

        private void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats + Loadout.Stats;
        }

        #endregion
    }
}
