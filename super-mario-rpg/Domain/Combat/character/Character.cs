using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        private static readonly CharacterValidator Validator = new CharacterValidator();

        public Character(CharacterBuilderBase builderBase) : base(builderBase.Id)
        {
            CharacterType = builderBase.CharacterType;
            Loadout = builderBase.Loadout;
            NaturalStats = builderBase.NaturalStats;

            Validator.ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; }
        public Stats EffectiveStats => NaturalStats + Loadout.Stats;
        public Loadout Loadout { get; private set; }
        public Stats NaturalStats { get; }
        public Equipment Accessory => Loadout.Accessory;
        public Equipment Armor => Loadout.Armor;
        public Equipment Weapon => Loadout.Weapon;

        public Character Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            Validator.ValidateAndThrow(this);
            return this;
        }

        #endregion
    }
}
