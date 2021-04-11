using System;
using System.Linq;
using Effort.Domain;
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

        #region IRepository<Enemy> Implementation

        public string Create(Enemy enemy)
        {
            return Create(Character.From(enemy)).Name;
        }

        public void Create(params Enemy[] enemies)
        {
            Create(enemies.Select(Character.From).ToArray());
        }

        public Enemy Find(Id id)
        {
            throw new NotImplementedException();
        }

        public void Update(Enemy root)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
