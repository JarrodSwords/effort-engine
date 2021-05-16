namespace SuperMarioRpg.Domain.Combat
{
    public class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(IPlayableCharacterBuilder builder) : base(builder)
        {
            Statistics = builder.GetStatistics();
        }

        #endregion

        #region Public Interface

        public Statistics Statistics { get; set; }

        #endregion
    }
}
