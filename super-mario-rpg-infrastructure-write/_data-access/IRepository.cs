using System;
using System.Linq.Expressions;

namespace SuperMarioRpg.Infrastructure.Write
{
    public interface IRepository<T> where T : Entity
    {
        #region Public Interface

        void Commit();
        T Create(T entity);
        void Create(params T[] entities);
        T Find(Guid id);
        T Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);

        #endregion
    }
}
