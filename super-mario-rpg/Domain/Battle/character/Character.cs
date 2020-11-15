using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(CharacterBuilder builder) : base(builder.Id)
        {
            EffectiveStats = builder.EffectiveStats;
            Loadout = builder.Loadout;
            NaturalStats = builder.NaturalStats;
        }

        #endregion

        #region Public Interface

        public Stats EffectiveStats { get; }
        public Loadout Loadout { get; }
        public Stats NaturalStats { get; }

        #endregion
    }
}
