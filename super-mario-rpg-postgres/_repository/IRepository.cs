using System;
using System.Linq.Expressions;

namespace SuperMarioRpg.Postgres
{
    public interface IRepository<T>
    {
        #region Public Interface

        void Commit();
        T Create(T entity);
        T Find(Guid id);
        T Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);

        #endregion
    }
}
