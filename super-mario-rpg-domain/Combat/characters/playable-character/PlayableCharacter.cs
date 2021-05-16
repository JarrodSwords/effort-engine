namespace SuperMarioRpg.Domain.Combat
{
    public class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(IPlayableCharacterBuilder builder) : base(builder)
        {
            BaseStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; set; }

        #endregion
    }
}
