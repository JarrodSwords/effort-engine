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
        public Statistics Statistics { get; set; }
        public Equipment Weapon => Loadout.Weapon;

        public PlayableCharacter Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }

        #endregion

        #region Private Interface

        private Loadout Loadout { get; set; }

        #endregion
    }
}
