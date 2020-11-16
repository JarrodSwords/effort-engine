using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Character : AggregateRoot
    {
        #region Core

        public Character(CharacterBuilderBase builderBase) : base(builderBase.Id)
        {
            CharacterType = builderBase.CharacterType;
            Loadout = builderBase.Loadout;
            NaturalStats = builderBase.NaturalStats;
            EffectiveStats = NaturalStats + Loadout.Stats;

            new CharacterValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; }
        public Stats EffectiveStats { get; }
        public Loadout Loadout { get; private set; }
        public Stats NaturalStats { get; }
        public Equipment Weapon => Loadout.Weapon;

        public void Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
        }

        #endregion
    }
}
