using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private ExperiencePoints _experiencePoints;
        private Loadout _loadout;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            _experiencePoints = builder.ExperiencePoints;
            Level = builder.Level;
            NaturalStats = builder.NaturalStats;
            Loadout = builder.Loadout;

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public Level Level { get; private set; }
        public Stats NaturalStats { get; private set; }

        public ExperiencePoints ExperiencePoints
        {
            get => _experiencePoints;
            private set
            {
                _experiencePoints = value;
                LevelUp();
            }
        }

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

        public List<LevelReward> LevelRewards =>
            new List<LevelReward>
            {
                new LevelReward(1, 0, Stats.Default),
                new LevelReward(2, 16, new Stats(3, 2, 5, 2, 2)),
                new LevelReward(3, 48, new Stats(3, 2, 5, 2, 2)),
                new LevelReward(4, 84, new Stats(3, 2, 5, 2, 2))
            };

        public ExperiencePoints ToNext =>
            new ExperiencePoints(
                (ushort) (LevelRewards.First(x => x.Level.Value > Level.Value).Required.Value - ExperiencePoints.Value)
            );

        public ExperiencePoints Add(ExperiencePoints experiencePoints)
        {
            var xpToAdd = new ExperiencePoints(Math.Min(experiencePoints.Value, ToNext.Value));
            var remainder = new ExperiencePoints((ushort) (experiencePoints.Value - xpToAdd.Value));

            ExperiencePoints += xpToAdd;

            return remainder;
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

        private void LevelUp()
        {
            var rewards = LevelRewards.SingleOrDefault(x => x.Required == ExperiencePoints);

            if (rewards is null || Level == rewards.Level)
                return;

            Level = rewards.Level;
            NaturalStats += rewards.Stats;
        }

        #endregion
    }
}
