namespace SuperMarioRpg.Domain
{
    public partial class Enemy : Character
    {
        #region Creation

        public Enemy(ICharacterBuilder builder) : base(builder)
        {
            CombatStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats CombatStats { get; }

        #endregion
    }
}
