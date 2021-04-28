using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public class PlayableCharacter : Character
    {
        #region Creation

        public PlayableCharacter(ICharacterBuilder characterBuilder) : base(characterBuilder)
        {
            BaseStats = characterBuilder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; set; }

        #endregion
    }
}
