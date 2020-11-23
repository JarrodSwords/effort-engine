using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        private static readonly CharacterValidator Validator = new CharacterValidator();
        private Loadout _loadout;
        private Progression _progression;
        private Status _status;

        #region Creation

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            Progression = new Standard(this, builder.Xp);
            NaturalStats = builder.NaturalStats;
            Status = new Status();
            Loadout = new Loadout(builder.Accessory, builder.Armor, builder.Weapon);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }

        public Loadout Loadout
        {
            get => _loadout;
            set
            {
                _loadout = value;
                EffectiveStats = CreateEffectiveStats();
                Status = CreateStatus();
                Validator.ValidateAndThrow(this);
            }
        }

        public Stats NaturalStats { get; private set; }

        public Progression Progression
        {
            get => _progression;
            private set
            {
                _progression = value;
                _progression.LeveledUp += Add;
            }
        }

        public Status Status
        {
            get => _status;
            private set
            {
                if (_status == value)
                    return;

                _status = value;

                Progression = CreateProgression();
            }
        }

        public Character Add(Xp xp)
        {
            Progression = Progression.Add(xp);
            return this;
        }

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }


        public bool IsEquipped(Equipment equipment) => Loadout.IsEquipped(equipment);

        public Character Unequip(Id id)
        {
            Loadout = Loadout.Unequip(id);
            return this;
        }

        #endregion

        #region Private Interface

        private void Add(object sender, Stats reward)
        {
            NaturalStats += reward;
        }

        private Stats CreateEffectiveStats() => NaturalStats + Loadout.GetStats();

        private Progression CreateProgression() =>
            (Status.Buffs & Buffs.DoubleExperience) > 0
                ? Boosted.CreateProgression(this)
                : new Standard(this);

        private Status CreateStatus() => Loadout.GetStatuses();

        #endregion
    }
}
