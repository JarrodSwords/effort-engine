namespace SuperMarioRpg.Domain.Characters
{
    public partial class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(IBuilder builder) : base(builder)
        {
            BaseStats = builder.GetPlayableCharacterCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; set; }

        #endregion
    }
}
