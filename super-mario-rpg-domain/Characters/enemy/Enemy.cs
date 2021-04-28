using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public class Enemy : Character
    {
        #region Creation

        public Enemy(ICharacterBuilder characterBuilder) : base(characterBuilder)
        {
            BaseStats = characterBuilder.GetEnemyCombatStats();
        }

        #endregion

        #region Public Interface

        public EnemyCombatStats BaseStats { get; }

        #endregion
    }
}
