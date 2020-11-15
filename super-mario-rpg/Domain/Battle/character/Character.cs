using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(CharacterBuilderBase builderBase) : base(builderBase.Id)
        {
            EffectiveStats = builderBase.EffectiveStats;
            Loadout = builderBase.Loadout;
            NaturalStats = builderBase.NaturalStats;
        }

        #endregion

        #region Public Interface

        public Stats EffectiveStats { get; }
        public Loadout Loadout { get; }
        public Stats NaturalStats { get; }

        #endregion
    }
}
