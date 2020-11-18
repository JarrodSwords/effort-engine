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
        private Loadout _loadout;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            ExperiencePoints = builder.ExperiencePoints;
            Level = builder.Level;
            _loadout = builder.Loadout;
            NaturalStats = builder.NaturalStats;
            CalculateEffectiveStats();

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public ExperiencePoints ExperiencePoints { get; private set; }
        public Level Level { get; private set; }
        public Stats NaturalStats { get; private set; }

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

        public Character Add(ref ExperiencePoints remainingXp)
        {
            var xpToAdd = new ExperiencePoints(Math.Min(remainingXp.Value, ToNext.Value));
            remainingXp = new ExperiencePoints((ushort) (remainingXp.Value - xpToAdd.Value));

            ExperiencePoints += xpToAdd;

            var previousLevel = Level;

            Level = LevelRewards.FindLast(x => x.Required.Value <= ExperiencePoints.Value).Level;

            NaturalStats = LevelRewards
                .SkipWhile(x => x.Level.Value <= previousLevel.Value)
                .TakeWhile(x => x.Level.Value <= Level.Value)
                .Select(x => x.Stats)
                .Aggregate(NaturalStats, (x, y) => x + y);

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
