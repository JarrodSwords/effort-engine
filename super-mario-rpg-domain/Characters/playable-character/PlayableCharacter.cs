using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(ICharacterBuilder builder) : base(builder)
        {
            BaseStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; set; }

        #endregion
    }
}
