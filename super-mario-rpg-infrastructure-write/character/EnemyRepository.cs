using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
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
            return Create(Character.From(enemy)).Name;
        }

        public void Create(params Enemy[] enemies)
        {
            Create(enemies.Select(Character.From).ToArray());
        }

        #endregion
    }
}
