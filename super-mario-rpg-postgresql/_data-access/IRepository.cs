using System;
using System.Linq.Expressions;

namespace SuperMarioRpg.Postgresql
{
    public interface IRepository<T> where T : Entity
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
