using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class PlayerCharacter : AggregateRoot
    {
        #region Creation

        public PlayerCharacter(IPlayerCharacterBuilder builder) : base(builder.GetId())
        {
            PlayableCharacter = builder.GetPlayableCharacter();
            Loadout = new Loadout();
        }

        #endregion

        #region Public Interface

        public Statistics EffectiveStatistics => PlayableCharacter.Statistics + Loadout.Statistics;
        public Statistics NaturalStatistics => PlayableCharacter.Statistics;
        public Equipment Weapon => Loadout.Weapon;

        public PlayerCharacter Equip(Equipment equipment)
        {
            Loadout = Loadout.Equip(equipment);
            return this;
        }

        #endregion

        #region Private Interface

        private Loadout Loadout { get; set; }
        private PlayableCharacter PlayableCharacter { get; }

        #endregion
    }
}
