using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        private static readonly CharacterValidator Validator = new();
        private Loadout _loadout;
        private Progression _progression;
        private Status _status;

        #region Creation

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            Name = builder.Name;
            CharacterType = builder.CharacterType;
            Progression = new Standard(builder.Xp);
            NaturalStats = builder.NaturalStats;
            Status = new Status();
            Loadout = new Loadout(builder.Accessory, builder.Armor, builder.Weapon);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats => NaturalStats + Loadout.GetStats();

        public Loadout Loadout
        {
            get => _loadout;
            set
            {
                _loadout = value;
                Status = CreateStatus();
                Validator.ValidateAndThrow(this);
            }
        }

        public Name Name { get; }
        public Stats NaturalStats { get; private set; }

        public Progression Progression
        {
            get => _progression;
            private set
            {
                if (_progression == value)
                    return;

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

        public Character Unequip(Equipment equipment)
        {
            Loadout = Loadout.Unequip(equipment);
            return this;
        }

        #endregion

        #region Private Interface

        private void Add(object sender, Stats reward)
        {
            NaturalStats += reward;
        }

        private Progression CreateProgression()
        {
            if (Progression.Xp == Progression.Max)
                return new Maxed();

            if (Status.Buffs.Contains(Buffs.DoubleXp))
                return new Boosted(Progression.Xp);

            return new Standard(Progression.Xp);
        }

        private Status CreateStatus() => Loadout.GetStatus();

        #endregion
    }
}
