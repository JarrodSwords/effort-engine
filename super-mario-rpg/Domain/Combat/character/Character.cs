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
        private Xp _xp;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            _xp = builder.Xp;
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

        public Xp Xp
        {
            get => _xp;
            private set
            {
                _xp = value;
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
                new LevelReward(2, 16, Stats.Create(3, 2, 5, 2, 2)),
                new LevelReward(3, 48, Stats.Create(3, 2, 5, 2, 2)),
                new LevelReward(4, 84, Stats.Create(3, 2, 5, 2, 2))
            };

        public Xp ToNext =>
            Xp.Create((ushort) (LevelRewards.First(x => x.Level.Value > Level.Value).Required.Value - Xp.Value));

        public Xp Add(Xp xp)
        {
            var delta = Xp.Create(Math.Min(xp.Value, ToNext.Value));
            var remainder = Xp.Create((ushort) (xp.Value - delta.Value));

            Xp += delta;

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
            var rewards = LevelRewards.SingleOrDefault(x => x.Required == Xp);

            if (rewards is null || Level == rewards.Level)
                return;

            Level = rewards.Level;
            NaturalStats += rewards.Stats;
        }

        #endregion
    }
}
