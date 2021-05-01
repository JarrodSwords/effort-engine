using System;
using System.Linq.Expressions;

namespace SuperMarioRpg.Infrastructure.Write
{
    public interface IRepository<T> where T : Entity
    {
        void Commit();
        T Create(T entity);
        void Create(params T[] entities);
        void Delete(T entity);
        T Find(Guid id);
        T Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
    }
}
