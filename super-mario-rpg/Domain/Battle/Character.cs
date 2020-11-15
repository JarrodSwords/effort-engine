using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(Guid id = new Guid(), Stats stats = null) : base(id)
        {
            Stats = stats;
        }

        public Character(CharacterBuilder builder)
        {
            Loadout = builder.Loadout;
            Stats = builder.Stats;
        }

        #endregion

        #region Public Interface

        public Loadout Loadout { get; }
        public Stats Stats { get; }

        #endregion
    }
}
