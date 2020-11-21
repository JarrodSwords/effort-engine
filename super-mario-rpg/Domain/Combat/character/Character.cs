using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        private static readonly CharacterValidator Validator = new CharacterValidator();
        private Loadout _loadout;

        #region Creation

        public Character(ICharacterBuilder builder) : base(builder.Id)
        {
            CharacterType = builder.CharacterType;
            ProgressionSystem = new ProgressionSystem(builder.Xp);
            ProgressionSystem.LeveledUp += Add;
            NaturalStats = builder.NaturalStats;
            Loadout = new Loadout(builder.Accessory, builder.Armor, builder.Weapon);
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; }
        public Stats EffectiveStats { get; private set; }
        public Level Level => ProgressionSystem.CurrentLevel;

        public Loadout Loadout
        {
            get => _loadout;
            set
            {
                _loadout = value;
                CalculateEffectiveStats();
                Validator.ValidateAndThrow(this);
            }
        }

        public Stats NaturalStats { get; private set; }
        public Xp Xp => ProgressionSystem.Xp;

        public Character Add(Xp xp)
        {
            ProgressionSystem = ProgressionSystem.Add(xp);
            return this;
        }

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);

            if (equipment.EquipmentType == EquipmentType.ExpBooster)
                ProgressionSystem = ProgressionSystem.Set(new Boosted(ProgressionSystem));

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

        private IProgressionSystem ProgressionSystem { get; set; }

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
