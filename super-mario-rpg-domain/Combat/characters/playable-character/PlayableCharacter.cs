namespace SuperMarioRpg.Domain.Combat
{
    public class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(IPlayableCharacterBuilder builder) : base(builder)
        {
            Statistics = builder.GetStatistics();
            Loadout = new Loadout();
        }

        #endregion

        #region Public Interface

        public Statistics EffectiveStatistics => Statistics + Loadout.Statistics;
        public Loadout Loadout { get; set; }
        public Statistics Statistics { get; set; }

        public PlayableCharacter Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }

        #endregion
    }
}
