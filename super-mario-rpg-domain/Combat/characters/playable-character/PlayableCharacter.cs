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

        public Statistics EffectiveStatistics => Statistics + Weapon.Statistics;
        public Statistics Statistics { get; set; }

        public Equipment Weapon { get; private set; }

        public PlayableCharacter Equip(Equipment equipment)
        {
            Weapon = equipment;
            return this;
        }

        #endregion
    }
}
