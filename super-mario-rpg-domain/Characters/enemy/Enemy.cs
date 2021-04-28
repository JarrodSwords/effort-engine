namespace SuperMarioRpg.Domain.Characters
{
    public partial class Enemy : Character
    {
        #region Creation

        public Enemy(IBuilder builder) : base(builder)
        {
            BaseStats = builder.GetEnemyCombatStats();
        }

        #endregion

        #region Public Interface

        public CombatStats BaseStats { get; }

        #endregion
    }
}
