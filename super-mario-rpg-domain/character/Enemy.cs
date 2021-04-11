namespace SuperMarioRpg.Domain
{
    public partial class Enemy : Character
    {
        #region Creation

        public Enemy(ICharacterBuilder builder) : base(builder)
        {
            BaseStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; }

        #endregion
    }
}
