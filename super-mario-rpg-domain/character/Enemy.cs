namespace SuperMarioRpg.Domain
{
    public class Enemy : Character
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

        #region Nested Types

        public new interface IRepository : IRepository<Enemy>
        {
        }

        #endregion
    }
}
