using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(CharacterBuilder builder) : base(builder.Id)
        {
            if (builder.Loadout != null && !builder.Loadout.CheckCompatibility(builder.Character))
                throw new ArgumentException();

            Loadout = builder.Loadout;
            Stats = builder.Stats;

            EffectiveStats = Stats;

            if (Loadout?.Accessory != null)
                EffectiveStats += Loadout.Accessory.Stats;

            if (Loadout?.Armor != null)
                EffectiveStats += Loadout.Armor.Stats;

            if (Loadout?.Weapon != null)
                EffectiveStats += Loadout.Weapon.Stats;
        }

        #endregion

        #region Public Interface

        public Stats EffectiveStats { get; }
        public Loadout Loadout { get; }
        public Stats Stats { get; }

        #endregion
    }
}
