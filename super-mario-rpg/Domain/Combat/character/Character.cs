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
            EffectiveStats = NaturalStats
                           + Loadout.Accessory.Stats
                           + Loadout.Armor.Stats
                           + Loadout.Weapon.Stats;

            new CharacterValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; }
        public Stats EffectiveStats { get; }
        public Loadout Loadout { get; }
        public Stats NaturalStats { get; }

        #endregion
    }
}
