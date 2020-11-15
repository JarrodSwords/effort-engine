using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(CharacterBuilder builder) : base(builder.Id)
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
