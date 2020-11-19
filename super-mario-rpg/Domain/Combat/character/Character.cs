using Effort.Domain;
using FluentValidation;
using static System.Math;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();
        private ILoadout _loadout;
        private ProgressionStats _progressionStats;

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            ProgressionStats = new ProgressionStats(builder.Xp, builder.Levels);
            NaturalStats = builder.NaturalStats;
            Loadout = new Loadout(builder.Accessory, builder.Armor, builder.Weapon);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public Stats NaturalStats { get; private set; }

        public Level Level => ProgressionStats.CurrentLevel;
        public Xp Xp => ProgressionStats.CurrentXp;
        public Equipment Accessory => Loadout.GetEquipment(Slot.Accessory);
        public Equipment Armor => Loadout.GetEquipment(Slot.Armor);
        public Equipment Weapon => Loadout.GetEquipment(Slot.Weapon);

        public Xp Add(Xp xp)
        {
            var delta = CreateXp(Min(xp.Value, ProgressionStats.ToNext.Value));
            var remainder = CreateXp((ushort) (xp.Value - delta.Value));

            ProgressionStats = ProgressionStats.Add(delta);

            return remainder;
        }

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }

        public Equipment GetEquipment(Slot slot) => Loadout.GetEquipment(slot);

        public Character Unequip(Id id)
        {
            Loadout = Loadout.Unequip(id);
            return this;
        }

        #endregion

        #region Private Interface

        private ProgressionStats ProgressionStats
        {
            get => _progressionStats;
            set
            {
                _progressionStats = value;
                ProgressionStats.LeveledUp += Add;
            }
        }

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

        private void Add(object sender, Stats reward)
        {
            NaturalStats += reward;
        }

        private void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats + Loadout.GetStats();
        }

        #endregion
    }
}
