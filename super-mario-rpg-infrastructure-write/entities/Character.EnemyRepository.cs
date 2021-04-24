using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Creation

        public Character(Enemy enemy) : this(enemy as Domain.Character)
        {
            CombatStats = enemy.BaseStats;
        }

        #endregion

        #region Static Interface

        public static Character AsCharacter(Enemy enemy)
        {
            return enemy;
        }

        public static implicit operator Character(Enemy enemy)
        {
            return new(enemy);
        }

        #endregion

        public class EnemyRepository : Repository<Character>, Enemy.IRepository
        {
            #region Creation

            public EnemyRepository(Context context) : base(context)
            {
            }

            #endregion

            #region IRepository Implementation

            public string Create(Enemy enemy)
            {
                return base.Create(enemy).Name;
            }

            public void Create(params Enemy[] enemies)
            {
                Create(enemies.Select(AsCharacter).ToArray());
            }

            #endregion
        }
    }
}
