using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;
using FluentValidation;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private ILoadout _loadout;
        private Xp _xp;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            _xp = builder.Xp;
            Level = builder.Level;
            NaturalStats = builder.NaturalStats;
            Loadout = new SimpleLoadout(builder.Accessory, builder.Armor, builder.Weapon);
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

        public Equipment Accessory => Loadout.GetEquipment(Slot.Accessory);
        public Equipment Armor => Loadout.GetEquipment(Slot.Armor);
        public Equipment Weapon => Loadout.GetEquipment(Slot.Weapon);

        public List<LevelReward> LevelRewards =>
            new List<LevelReward>
            {
                new LevelReward(1, 0, Default),
                new LevelReward(2, 16, CreateStats(3, 2, 5, 2, 2)),
                new LevelReward(3, 48, CreateStats(3, 2, 5, 2, 2)),
                new LevelReward(4, 84, CreateStats(3, 2, 5, 2, 2))
            };

        public Xp ToNext =>
            CreateXp((ushort) (LevelRewards.First(x => x.Level.Value > Level.Value).Required.Value - Xp.Value));

        public Xp Add(Xp xp)
        {
            var delta = CreateXp(Math.Min(xp.Value, ToNext.Value));
            var remainder = CreateXp((ushort) (xp.Value - delta.Value));

            Xp += delta;

            return remainder;
        }

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }

        public Character Unequip(Id id)
        {
            Loadout = Loadout.Unequip(id);
            return this;
        }

        #endregion

        #region Private Interface

        private ILoadout Loadout
        {
            get => _loadout;
            set
            {
                _loadout = value;
                CalculateEffectiveStats();
                Validator.ValidateAndThrow(this);
            }
        }

        private void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats + Loadout.GetStats();
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
