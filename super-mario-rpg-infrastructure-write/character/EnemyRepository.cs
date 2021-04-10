using System;
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

        public string Create(Enemy root)
        {
            return Create(Character.From(root)).Name;
        }

        public void Create(params Enemy[] root)
        {
            throw new NotImplementedException();
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
