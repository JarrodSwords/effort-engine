using System;
using System.Linq;
using System.Linq.Expressions;

namespace SuperMarioRpg.Infrastructure.Write
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly Context Context;

        #region Creation

        protected Repository(Context context)
        {
            Context = context;
        }

        #endregion

        #region IRepository<T> Implementation

        public void Commit()
        {
            Context.SaveChanges();
        }

        public T Create(T entity)
        {
            return Context.Add(entity).Entity;
        }

        public void Create(params T[] entities)
        {
            Context.AddRange(entities.ToList());
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public T Find(Guid id)
        {
            return Context.Find<T>(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Context
                .Set<T>()
                .AsQueryable()
                .Single(predicate);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }

        #endregion
    }
}
